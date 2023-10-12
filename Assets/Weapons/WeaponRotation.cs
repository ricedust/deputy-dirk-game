using System;
using UnityEngine;

public class WeaponRotation : MonoBehaviour {
    [SerializeField] private WeaponAiming aiming;
    private void Update() {
        transform.rotation = aiming.rotation;
        // flip gun when facing left
        transform.localScale = new Vector2(1, aiming.direction.x > 0 ? 1 : -1);
    }
}