using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRecoil : MonoBehaviour {
    
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private InputReader input;
    [SerializeField] private WeaponSettings settings;
    [SerializeField] private WeaponAiming aiming;

    private void OnEnable() {
        input.shoot.performed += Recoil;
    }

    private void OnDisable() {
        input.shoot.performed -= Recoil;
    }

    private void Recoil(InputAction.CallbackContext context) {
        rigidBody.AddForce(aiming.direction * -1 * settings.recoilImpulse, ForceMode2D.Impulse);
    }
}