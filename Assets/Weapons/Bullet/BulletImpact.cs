using System.Threading;
using UnityEngine;

public class BulletImpact : MonoBehaviour {
    [SerializeField] private BulletInitializer initializer;
    [SerializeField] private Pool bulletPool;
    [SerializeField] private Rigidbody2D rigidBody;
    private float knockbackImpulse;
    private bool isPiercing;

    private void OnEnable() {
        initializer.onInitialization += Setup;
    }

    private void OnDisable() {
        initializer.onInitialization -= Setup;
    }

    private void Setup(BulletSettings settings) {
        knockbackImpulse = settings.knockbackImpulse;
        isPiercing = settings.isPiercing;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // ensure the other object receives bullets
        if (!other.TryGetComponent(out BulletReceiver _)) return;
        other.attachedRigidbody.AddForce(rigidBody.velocity.normalized * knockbackImpulse, ForceMode2D.Impulse);

        // if piercing is not enabled, return bullet to pool
        if (isPiercing) return;
        bulletPool.Release(gameObject);
    }
}