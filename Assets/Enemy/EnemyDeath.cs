using System;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
    [SerializeField] private BulletReceiver bulletReceiver;
    [SerializeField] private BehaviorGroup toDisable;

    public event Action onDeath;
    private void OnEnable() {
        toDisable.SetEnabled(true);
        bulletReceiver.onHit += Die;
    }

    private void OnDisable() {
        bulletReceiver.onHit -= Die;
    }

    private void Die() {
        toDisable.SetEnabled(false);
        onDeath?.Invoke();
    }
}