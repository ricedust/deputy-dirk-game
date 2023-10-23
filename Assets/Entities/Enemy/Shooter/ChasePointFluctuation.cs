using UnityEngine;

public class ChasePointFluctuation : MonoBehaviour {
    [SerializeField] private ShooterSettings settings;
    [SerializeField] private PlayerData player;

    /// <summary>
    /// Seed for Perlin noise.
    /// </summary>
    private float noiseOffset;
    /// <summary>
    /// A point that Lerps behind the origin to make the chasing behavior less rigid.
    /// </summary>
    private Vector2 displacedOrigin;
    /// <summary>
    /// The chase point position relative to the displaced origin.
    /// </summary>
    private Vector2 chasePoint;

    private void OnEnable() {
        noiseOffset = Random.Range(0, 100);
        displacedOrigin = player.position;
        // pick a random point along the chase radius to start
        chasePoint = Quaternion.Euler(0, 0, Random.Range(0f, 360f)) * Vector2.right * 
            Random.Range(settings.chaser.minChaseRadius, settings.chaser.maxChaseRadius);
    }

    private void Update() {
        
        // update the lagging origin
        displacedOrigin = Vector2.Lerp(displacedOrigin, player.position, settings.chaser.trackingDamping);

        // create a rotation using noise, mapped between -1 and 1
        float noise = Mathf.PerlinNoise1D(Time.time + noiseOffset) * 2 - 1;
        float rotationToAdd = noise * settings.chaser.strafeSpeed * Time.deltaTime;

        // add it to the current orbit
        chasePoint = Quaternion.Euler(0, 0, rotationToAdd) * chasePoint;
        transform.position = displacedOrigin + chasePoint;
    }    
}