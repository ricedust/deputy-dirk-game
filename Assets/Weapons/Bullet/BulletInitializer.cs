using System;
using UnityEngine;

public class BulletInitializer : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Collider2D trigger;
    [SerializeField] private TrailRenderer trail;

    public event Action<BulletSettings> onInitialization;

    public void Initialize(Vector2 direction, BulletSettings settings, LayerMask gunOwner) {
        rigidBody.velocity = direction * settings.speed;
        trigger.excludeLayers = gunOwner;
        trail.Clear();
        onInitialization?.Invoke(settings);
    }
}

[Serializable]
public struct BulletSettings {
    
    [field: SerializeField] public float speed { get; private set; }
    [field: SerializeField] public int bounces { get; private set; }
    [field: SerializeField] public bool isPiercing { get; private set; }
}