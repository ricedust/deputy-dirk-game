using System;
using Cinemachine;
using UnityEngine;

public class WeaponFiring : MonoBehaviour {
    [SerializeField] private WeaponAiming aiming;
    [SerializeField] private WeaponSettings weaponSettings;
    [SerializeField] private Pool bulletPool;
    [SerializeField] private BulletSettings bulletSettings;
    [SerializeField] private Transform bulletSource;
    [SerializeField] private LayerMask gunOwner;
    [SerializeField] private CinemachineImpulseSource cameraShake;

    public event Action onFire;

    public void Fire() {
        GameObject bullet = bulletPool.Get();
        bullet.transform.position = bulletSource.position;
        bullet.transform.rotation = bulletSource.rotation;

        if (!bullet.TryGetComponent(out BulletInitializer bulletInitializer)) return;
        // set bullet velocity and provide layermask for gunowner
        bulletInitializer.Initialize(aiming.direction, bulletSettings, gunOwner);

        // invoke event
        onFire?.Invoke();

        // shake camera relative to firing directino
        cameraShake?.GenerateImpulse(bulletSource.rotation * Vector2.left * weaponSettings.cameraShakeMagnitude);
    }
}