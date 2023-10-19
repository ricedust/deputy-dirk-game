using UnityEngine;

public class BulletDeflection : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidBody;
    private void OnCollisionEnter2D() {
        transform.rotation = Quaternion.FromToRotation(Vector2.right, rigidBody.velocity);
    }
}