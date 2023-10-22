using System;
using UnityEngine;

public class BulletCollision : MonoBehaviour {
    [SerializeField] private Pool bulletPool;
    [SerializeField] private BulletInitializer initializer;
    [SerializeField] private Rigidbody2D rigidBody;
    private int bouncesRemaining;
    private bool isPiercing;

    private void OnEnable() {
        initializer.onInitialization += Setup;
    }
    private void OnDisable() {
        initializer.onInitialization -= Setup;
    }

    private void Setup(BulletSettings settings) {
        bouncesRemaining = settings.bounces;
        isPiercing = settings.isPiercing;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // deflect the bullet after collision
        transform.rotation = Quaternion.FromToRotation(Vector2.right, rigidBody.velocity);
        
        // decrement bounces
        if (bouncesRemaining > 0) {
            bouncesRemaining--;
            return;
        }
        // return bullet to pool when no bounces remain
        bulletPool.Release(gameObject);
    }
}