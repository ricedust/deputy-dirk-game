using UnityEngine;

public class BulletExpiration : MonoBehaviour {
    [SerializeField] private Pool bulletPool;
    [SerializeField] private BulletInitializer initializer;
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

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.TryGetComponent(out BulletReceiver _)) return;
        if (isPiercing) return;
        bulletPool.Release(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (bouncesRemaining > 0) {
            bouncesRemaining--;
            return;
        }
        bulletPool.Release(gameObject);
    }
}