using System;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
    [SerializeField] private BulletReceiver bulletReceiver;
    [SerializeField] private Behaviour[] componentsToDisable;

    public event Action onDeath;
    private void OnEnable() {
        bulletReceiver.onHit += Die;
    }

    private void OnDisable() {
        bulletReceiver.onHit -= Die;
    }

    private void Die() {
        Array.ForEach(componentsToDisable, component => component.enabled = false);
        onDeath?.Invoke();
    }
}