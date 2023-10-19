using System;
using UnityEngine;

public class BulletReceiver : MonoBehaviour {
    [SerializeField] private LayerMask bulletLayer;
    public event Action onHit;

    private void OnTriggerEnter2D(Collider2D other) {
        if (1 << other.gameObject.layer != bulletLayer) return;
        onHit?.Invoke();
        Debug.Log(bulletLayer);
    }
}