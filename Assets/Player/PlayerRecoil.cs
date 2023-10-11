using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRecoil : MonoBehaviour {
    
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerInput input;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private WeaponAiming aiming;

    private void OnEnable() {
        input.shoot.performed += Recoil;
    }

    private void OnDisable() {
        input.shoot.performed -= Recoil;
    }

    private void Recoil(InputAction.CallbackContext context) {
        rigidBody.AddForce(aiming.direction * -1 * playerData.recoilImpulse, ForceMode2D.Impulse);
    }
}