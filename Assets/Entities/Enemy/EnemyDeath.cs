using System;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
    [SerializeField] private BulletReceiver bulletReceiver;
    [SerializeField] private BehaviorGroup toDisable;
    [SerializeField] private Despawner despawner;
    [SerializeField] private Pool pool;
    private bool isDead;
    public event Action onDeath;
    private void OnEnable() {
        toDisable.SetEnabled(true);
        isDead = false;
        bulletReceiver.onHit += Die;
    }

    private void OnDisable() {
        bulletReceiver.onHit -= Die;
    }

    private void Die() {
        if (isDead) return;

        toDisable.SetEnabled(false);
        isDead = true;
        despawner.Despawn(pool);
        onDeath?.Invoke();
    }
}