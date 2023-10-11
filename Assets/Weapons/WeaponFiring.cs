using System;
using UnityEngine;

public class WeaponFiring : MonoBehaviour {
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private WeaponData weaponData;
    [SerializeField] private Transform bulletSource;

    public event Action onFire;

    public void Fire() {
        Transform bullet = Instantiate(bulletPrefab, bulletSource.position, bulletSource.rotation);

        // set the bullet velocity
        bullet.TryGetComponent(out Rigidbody2D rigidBody);
        rigidBody.velocity = transform.TransformDirection(Vector2.right) * weaponData.muzzleVelocity;

        // invoke event
        onFire?.Invoke();
    }
}