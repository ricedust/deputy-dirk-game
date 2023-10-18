using UnityEngine;

public class LightShooter : MonoBehaviour {
    [SerializeField] private WeaponAiming aiming;
    [SerializeField] private WeaponFiring firing;
    [SerializeField] private PlayerChannel player;

    private void Update() {
        aiming.AimAt(player.position);
    }
}