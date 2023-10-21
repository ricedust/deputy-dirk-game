using System;
using UnityEngine;

public class BulletInitializer : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Collider2D trigger;

    public event Action<BulletSettings> onInitialization;

    public void Initialize(Vector2 direction, BulletSettings settings, LayerMask gunOwner) {
        rigidBody.velocity = direction * settings.speed;
        trigger.excludeLayers = gunOwner;
        onInitialization?.Invoke(settings);
    }
}