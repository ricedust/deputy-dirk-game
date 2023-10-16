using UnityEngine;

public class Avoider : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private EnemySettings settings;
    [SerializeField] private PlayerChannel player;

    private void FixedUpdate() {
        // the vector from the player to this enemy
        Vector2 repelFrom = (Vector2)transform.position - player.position;

        // outside of avoid radius, no need to avoid
        if (repelFrom.magnitude > settings.avoidRadius) return;

        Vector2 repelForce = repelFrom.normalized * settings.avoidForce * Time.fixedDeltaTime;
        rigidBody.AddForce(repelForce);
    }
}