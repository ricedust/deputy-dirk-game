using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stealer : MonoBehaviour {
    [SerializeField] private Transform chasePoint;
    [SerializeField] private SpawnPointData spawn;
    [SerializeField] private TreasuryData treasury;
    [SerializeField] private ThiefSettings settings;
    [SerializeField] private BehaviorGroup toDisable;
    [SerializeField] private Despawner despawner;
    [SerializeField] private Pool pool;

    public event Action onSteal;
    public event Action<bool> onStolen;

    private void OnEnable() {
        toDisable.SetEnabled();
        StartCoroutine(ChaseBag());
    }

    private IEnumerator ChaseBag() {
        yield return new WaitForEndOfFrame();

        // keep updating chase point until the thief has closed the gap
        while (Vector2.Distance(treasury.location, transform.position) > settings.steal.radius) {
                    
            chasePoint.position = treasury.location;

            // escape if no money remains
            if (treasury.count == 0) {
                StartCoroutine(Escape());
                yield break;
            }

            yield return null;
        }
        StartCoroutine(Steal());
    }

    private IEnumerator Steal() {

        // escape if no money remains
        if (treasury.count == 0) {
            StartCoroutine(Escape());
            yield break;
        }

        toDisable.SetEnabled(false);
        onSteal?.Invoke();

        yield return new WaitForSeconds(settings.steal.duration);

        // invoke on stolen and pass on whether it was successful
        onStolen?.Invoke(treasury.count > 0);
        toDisable.SetEnabled();
        StartCoroutine(Escape());
    }

    private IEnumerator Escape() {

        // pick a random spawn point to escape to
        Transform escapePoint = spawn.points[Random.Range(0, spawn.points.Count)];

        // chase the spawn point until reaching it
        while(Vector2.Distance(escapePoint.position, transform.position) > settings.steal.escapeThreshold) {
            chasePoint.position = escapePoint.position;
            yield return null;
        }

        toDisable.SetEnabled(false);
        despawner.Despawn(pool);
    }
}

[Serializable]
public struct StealSettings {
    [field: SerializeField] public float radius { get; private set; }
    [field: SerializeField] public float duration { get; private set; }
    [field: SerializeField] public float escapeThreshold { get; private set; }
}