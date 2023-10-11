using System;
using UnityEngine;

public class WeaponRotation : MonoBehaviour {
    [SerializeField] private WeaponAiming aiming;
    private void Update() {
        transform.rotation = aiming.rotation;
        // flip gun when facing left
        transform.localScale = new Vector2(1, Math.Sign(aiming.direction.x));
    }
}