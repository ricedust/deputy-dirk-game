using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private InputReader input;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerSettings settings;

    private void FixedUpdate() {
        Vector2 moveDirection = input.move.ReadValue<Vector2>();
        rigidBody.AddForce(moveDirection * settings.moveForce * Time.fixedDeltaTime);
    }
}