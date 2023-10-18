using System;
using UnityEngine;

public class BulletReceiver : MonoBehaviour {
    [SerializeField] private LayerMask bulletLayer;
    public event Action onHit;
    private void OnCollisionEnter2D(Collision2D other) {
        if (1 << other.gameObject.layer != bulletLayer) return;
        Debug.Log(bulletLayer);
    }
}