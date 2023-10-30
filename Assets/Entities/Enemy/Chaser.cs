using UnityEngine;
using Random = UnityEngine.Random;

public class Chaser : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform chasePoint;
    [SerializeField] private EnemySettings settings;
    
    /// <summary>Seed for Perlin noise.</summary>
    private float noiseOffset;

    private void OnEnable() {
        noiseOffset = Random.Range(0, 100);
    }

    private void FixedUpdate() {
        Vector2 chaseDirection = ((Vector2)chasePoint.position - rigidBody.position).normalized;

        // add variation to chase direction using noise
        float angleOffset = Mathf.PerlinNoise1D(Time.time + noiseOffset) * 2 - 1;
        chaseDirection = Quaternion.Euler(0, 0, angleOffset * settings.moveVariation) * chaseDirection;

        rigidBody.AddForce(chaseDirection * settings.moveForce * Time.fixedDeltaTime);
    }
}