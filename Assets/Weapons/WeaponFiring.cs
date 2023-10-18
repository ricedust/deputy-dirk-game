using System;
using Cinemachine;
using UnityEngine;

public class WeaponFiring : MonoBehaviour {
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private WeaponSettings settings;
    [SerializeField] private Transform bulletSource;
    [SerializeField] private LayerMask gunOwner;
    [SerializeField] private CinemachineImpulseSource cameraShake;

    public event Action onFire;

    public void Fire() {
        Transform bullet = Instantiate(bulletPrefab, bulletSource.position, bulletSource.rotation);

        // set the bullet velocity
        if (!bullet.TryGetComponent<Rigidbody2D>(out Rigidbody2D bulletRigidbody)) return;
        bulletRigidbody.velocity = transform.TransformDirection(Vector2.right) * settings.muzzleVelocity;
        bulletRigidbody.excludeLayers = gunOwner;

        // invoke event
        onFire?.Invoke();
        cameraShake?.GenerateImpulse(UnityEngine.Random.insideUnitCircle * settings.cameraShakeMagnitude);
    }
}