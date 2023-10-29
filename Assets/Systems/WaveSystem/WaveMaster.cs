using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveMaster : MonoBehaviour {
    [SerializeField] private GameTick gameTick;
    [SerializeField] private UIData ui;
    [SerializeField] private WaveSettings settings;
    [SerializeField] private WaveData data;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private WaveState state;

    [Serializable]
    private struct WaveState {
        public int waveNumber;
        public WaveDistribution distribution;
        public bool isInIntermission;
        public int batchQuota;
        public int batchesSpawned;
    }
    private Coroutine batchSpawningRoutine;

    private void OnEnable() {
        ui.OnPlay += ExitIntermission;
        gameTick.onTick += CheckSpawnConditions;
        gameTick.onTick += CheckNextWaveConditions;
    }
    private void OnDisable() {
        ui.OnPlay -= ExitIntermission;
        gameTick.onTick -= CheckSpawnConditions; 
        gameTick.onTick -= CheckNextWaveConditions;
    }

    private void ExitIntermission() {
        StartCoroutine(DelayStart());
    }

    private IEnumerator DelayStart() {
        yield return new WaitForSeconds(settings.waveDelaySeconds);
        state.isInIntermission = false;
        data.RaiseOnWaveStart(state.waveNumber);
    }

    private void CheckSpawnConditions() {

        if (state.isInIntermission) return; // intermission
        if (state.batchesSpawned >= state.batchQuota) return; // batch quota met
        if (settings.enemyPools.CountTotalActive() > settings.newBatchThreshold) return; // too many still alive

        // start a batch spawn sequence
        int numBatches = Random.Range(settings.minBatchesAtOnce, settings.maxBatchesAtOnce + 1);

        if (batchSpawningRoutine != null) StopCoroutine(batchSpawningRoutine);
        batchSpawningRoutine = StartCoroutine(SpawnBatchesInSequence(numBatches)); 
    }

    private IEnumerator SpawnBatchesInSequence(int numBatches) {
        // create different batches in sequence
        var waitForSecondsInterval = new WaitForSeconds(settings.spawnIntervalSeconds);
        for (int i = 0; i < numBatches; i++) {

            // pick the size of the batch and spawn point
            int numEnemies = Random.Range(settings.minBatchSize, settings.maxBatchSize + 1);
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // create the batch using the current distribution
            for (int j = 0; j < numEnemies; j++) {
                GameObject enemy = state.distribution.GetEnemy();
                enemy.transform.position = spawnPoint.position;
            }

            // account for the new batch and return if the batch quota was met
            state.batchesSpawned++;
            if (state.batchesSpawned >= state.batchQuota) yield break;

            yield return waitForSecondsInterval;
        }
    }
    private void CheckNextWaveConditions()
    {
        if (state.batchesSpawned < state.batchQuota) return; // batch quota not met
        if (settings.enemyPools.CountTotalActive() > 0) return; // still enemies alive
        if (state.isInIntermission) return; // already in intermission

        data.RaiseOnWaveComplete(state.waveNumber);
        
        state = new WaveState {
            batchesSpawned = 0,
            batchQuota = state.batchQuota + settings.batchQuotaIncrease,
            distribution = settings.distributions[Random.Range(0, settings.distributions.Length)],
            isInIntermission = false,
            waveNumber = state.waveNumber + 1
        };

        StartCoroutine(DelayWaveStart());
    }

    private IEnumerator DelayWaveStart()
    {
        state.isInIntermission = true;
        Debug.Log("wave complete");

        yield return new WaitForSeconds(settings.waveDelaySeconds);

        Debug.Log("wave started");
        state.isInIntermission = false;
        data.RaiseOnWaveStart(state.waveNumber);
    }
}