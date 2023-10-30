using System;
using System.Collections;
using UnityEngine;

public class Stealer : MonoBehaviour {
    [SerializeField] private Transform chasePoint;
    [SerializeField] private SpawnPointData spawn;
    [SerializeField] private MoneyData money;
    [SerializeField] private ThiefSettings settings;
    [SerializeField] private BehaviorGroup toDisable;
    [SerializeField] private Despawner despawner;
    [SerializeField] private Pool pool;

    public event Action onSteal;
    public event Action onStolen;

    private void OnEnable() {
        toDisable.SetEnabled();
        StartCoroutine(ChaseBag());
    }

    private IEnumerator ChaseBag() {
        // keep updating chase point until the thief has closed the gap
        while (Vector2.Distance(money.location, transform.position) > settings.steal.radius) {
            chasePoint.position = money.location;
            yield return null;
        }
        StartCoroutine(Steal());
    }

    private IEnumerator Steal() {
        toDisable.SetEnabled(false);
        onSteal?.Invoke();

        yield return new WaitForSeconds(settings.steal.duration);

        onStolen?.Invoke();
        toDisable.SetEnabled();
        StartCoroutine(Escape());
    }

    private IEnumerator Escape() {

        // pick the closest spawn point
        Transform closest = spawn.points[0];
        float minDistance = Vector2.Distance(closest.position, transform.position);

        foreach (Transform point in spawn.points) {
            float distance = Vector2.Distance(point.position, transform.position);
            if (distance < minDistance) {
                closest = point;
                minDistance = distance;
            }
        }

        // chase the spawn point until reaching it
        while(Vector2.Distance(closest.position, transform.position) > settings.steal.escapeThreshold) {
            chasePoint.position = closest.position;
            Debug.Log(Vector2.Distance(closest.position, transform.position));
            yield return null;
        }
        despawner.Despawn(pool);
    }
}

[Serializable]
public struct StealSettings {
    [field: SerializeField] public float radius { get; private set; }
    [field: SerializeField] public float duration { get; private set; }
    [field: SerializeField] public float escapeThreshold { get; private set; }
}