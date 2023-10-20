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
        if (!bullet.TryGetComponent(out BulletInitializer bulletInitializer)) return;
        // set bullet velocity and provide layermask for gunowner
        bulletInitializer.Initialize(
            transform.TransformDirection(Vector2.right) * settings.muzzleVelocity,
            gunOwner
        );

        // invoke event
        onFire?.Invoke();

        // shake camera relative to firing directino
        cameraShake?.GenerateImpulse(bulletSource.rotation * Vector2.left * settings.cameraShakeMagnitude);
    }
}