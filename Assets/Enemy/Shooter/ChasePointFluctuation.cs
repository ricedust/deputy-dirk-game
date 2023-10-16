using UnityEngine;

public class ChasePointFluctuation : MonoBehaviour {
    [SerializeField] private ChaseSettings settings;
    [SerializeField] private PlayerChannel player;

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
        chasePoint = Quaternion.Euler(0, 0, Random.Range(0f, 360f)) * Vector2.right * 
            Random.Range(settings.minChaseRadius, settings.maxChaseRadius);
    }

    private void Update() {
        
        // update the lagging origin
        displacedOrigin = Vector2.Lerp(displacedOrigin, player.position, settings.trackingDamping);
        Debug.DrawLine(displacedOrigin, player.position);

        // create a rotation using noise
        float noise = Mathf.PerlinNoise1D(Time.time + noiseOffset) * 2 - 1;
        float rotationToAdd = noise * settings.strafeSpeed * Time.deltaTime;

        // add it to the current orbit
        chasePoint = Quaternion.Euler(0, 0, rotationToAdd) * chasePoint;
        transform.position = displacedOrigin + chasePoint;
    }    
}