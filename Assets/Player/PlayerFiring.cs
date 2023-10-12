using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFiring : MonoBehaviour {
    
    [SerializeField] private PlayerInput input;
    [SerializeField] private WeaponAiming aiming;
    [SerializeField] private WeaponFiring firing;
    private Camera cam;

    private void Awake() {
        cam = Camera.main;
    }

    private void OnEnable() {
        input.shoot.performed += Fire;
    }

    private void OnDisable() {
        input.shoot.performed -= Fire;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        firing.Fire();
    }

    public void Update()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(input.aim.ReadValue<Vector2>());
        aiming.FromTo(transform.position, mousePosition);
    }
}