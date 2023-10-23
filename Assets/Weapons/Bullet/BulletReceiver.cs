using System;
using Cinemachine;
using UnityEngine;

public class BulletReceiver : MonoBehaviour {
    [SerializeField] private LayerMask bulletLayer;
    [SerializeField] private CinemachineImpulseSource cameraShake;
    [SerializeField] private float shakeAmount;
    public event Action onHit;

    private void OnTriggerEnter2D(Collider2D other) {
        if (1 << other.gameObject.layer != bulletLayer) return;
        onHit?.Invoke();

        cameraShake?.GenerateImpulse(
            (transform.position - other.transform.position).normalized * shakeAmount
        );
    }
}