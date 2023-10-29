using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class WeaponFiring : MonoBehaviour {
    [SerializeField] private WeaponAiming aiming;
    [SerializeField] private WeaponSettings settings;
    [SerializeField] private Pool bulletPool;
    [SerializeField] private Transform bulletSource;
    [SerializeField] private LayerMask gunOwner;
    [SerializeField] private CinemachineImpulseSource cameraShake;
    [SerializeField] private AudioChannel audioChannel;


    private Coroutine burstFireRoutine;
    public bool isLocked { get; private set; }
    public event Action<WeaponAiming> onFire;
    public void SetLocked(bool isLocked) => this.isLocked = isLocked;

    private void OnDisable() {
        if (burstFireRoutine != null) StopCoroutine(burstFireRoutine);
    }

    public void Fire() {
        // don't fire if locked
        if (isLocked) return;

        // fire a burst if firing pattern is enabled
        if (settings.firingPattern.enabled) {
            if (burstFireRoutine != null) StopCoroutine(burstFireRoutine);
            burstFireRoutine = StartCoroutine(FireBurst());
            return;
        }

        FireSingle(); // otherwise just fire a single shot
    }

    private void FireSingle() {
        // get a bullet and apply transforms
        GameObject bullet = bulletPool.Get();
        bullet.transform.SetPositionAndRotation(bulletSource.position, bulletSource.rotation);

        // initialize the bullet
        if (!bullet.TryGetComponent(out BulletInitializer bulletInitializer)) return;
        bulletInitializer.Initialize(aiming.direction, settings.bullet, gunOwner);

        // invoke event
        onFire?.Invoke(aiming);

        // shake camera relative to firing direction
        cameraShake?.GenerateImpulse(aiming.direction * settings.cameraShakeMagnitude);
        
        // play sound
        audioChannel?.PlayAudioCue(settings.sound, transform.position);
    }

    private IEnumerator FireBurst() {
        for (int i = 0; i < settings.firingPattern.shotsPerBurst; i++) {
            FireSingle();
            yield return new WaitForSeconds(settings.firingPattern.secondsBetweenShots);
        }
    }

}

[Serializable]
public struct FiringPattern {
    [field: SerializeField] public bool enabled { get; private set; }
    [field: SerializeField] public float secondsBetweenShots { get; private set; }
    [field: SerializeField] public int shotsPerBurst { get; private set; }
}