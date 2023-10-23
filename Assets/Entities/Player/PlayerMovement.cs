using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private InputReader input;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Collider2D centerMass;
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private PlayerData data;

    private void FixedUpdate() {
        Vector2 moveDirection = input.move.ReadValue<Vector2>();
        rigidBody.AddForce(moveDirection * settings.moveForce * Time.fixedDeltaTime);
    }
    private void Update() {
        data.UpdatePosition((Vector2)transform.position + centerMass.offset);
    }
}