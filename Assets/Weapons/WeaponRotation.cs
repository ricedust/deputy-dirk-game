using UnityEngine;

public class WeaponRotation : MonoBehaviour {
    [SerializeField] private WeaponAiming aiming;
    private Vector2 scale;

    private void Awake() {
        scale = transform.localScale;
    }
    private void FixedUpdate() {
        transform.rotation = aiming.rotation;
        // flip gun when facing left
        transform.localScale = new Vector2(scale.x, 
            aiming.direction.x > 0 ? scale.y : -scale.y);
    }
}