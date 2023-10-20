using UnityEngine;

public class BulletInitializer : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Collider2D trigger;

    public void Initialize(Vector2 velocity, LayerMask gunOwner) {
        rigidBody.velocity = velocity;
        trigger.excludeLayers = gunOwner;
    }
}