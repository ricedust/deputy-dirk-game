using UnityEngine;

/// <summary>
/// Controls a focus point that drifts in the mouse direction.
/// </summary>
public class MouseFollower : MonoBehaviour {
    
    [SerializeField] private MouseFollowerSettings settings;
    [SerializeField] private Transform player;
    [SerializeField] private InputReader input;
    private Camera cam;

    private void Awake() {
        cam = Camera.main;
    }

    private void FixedUpdate() {
        // find where the camera should be relative to the player
        Vector2 mousePosition = cam.ScreenToWorldPoint(input.aim.ReadValue<Vector2>());
        Vector2 cameraPosition = player.InverseTransformPoint(mousePosition) * settings.mouseFollowRatio;
        
        // make sure the camera does not exceed maximum lookahead amount
        transform.position = player.TransformPoint(
            cameraPosition.magnitude > settings.maxLookAhead ? 
                cameraPosition.normalized * settings.maxLookAhead :
                cameraPosition
        );
            
    }
}