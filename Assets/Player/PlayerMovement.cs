using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private PlayerInput input;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerData playerData;

    private void FixedUpdate() {
        Vector2 moveDirection = input.move.ReadValue<Vector2>();
        rigidBody.AddForce(moveDirection * playerData.moveForce * Time.fixedDeltaTime);
    }
}