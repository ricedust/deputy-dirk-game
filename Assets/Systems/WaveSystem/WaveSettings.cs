using UnityEngine;

[CreateAssetMenu(menuName = "WaveSettings")]
public class WaveSettings : ScriptableObject {
    [field: SerializeField] public PoolGroup enemyPools { get; private set; }
    [field: SerializeField] public WaveDistribution[] distributions { get; private set; }
    [field: SerializeField] public int newBatchThreshold { get; private set; }
    [field: SerializeField] public int minBatchesAtOnce { get; private set; }
    [field: SerializeField] public int maxBatchesAtOnce { get; private set; }
    [field: SerializeField] public float spawnIntervalSeconds { get; private set; }
    [field: SerializeField] public int minBatchSize { get; private set; }
    [field: SerializeField] public int maxBatchSize { get; private set; }
    [field: SerializeField] public int batchQuotaIncrease { get; private set; }
    [field: SerializeField] public float waveDelaySeconds { get; private set; }
}