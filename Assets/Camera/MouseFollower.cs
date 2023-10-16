using UnityEngine;

/// <summary>
/// Controls a focus point that drifts in the mouse direction.
/// </summary>
public class MouseFollower : MonoBehaviour {
    
    [SerializeField] private MouseFollowerSettings settings;
    [SerializeField] private PlayerChannel player;
    [SerializeField] private InputReader input;
    private Camera cam;

    private void Awake() {
        cam = Camera.main;
    }

    private void FixedUpdate() {
        // find where the camera should be relative to the player
        Vector2 mousePosition = cam.ScreenToWorldPoint(input.aim.ReadValue<Vector2>());
        Vector2 cameraPosition = (mousePosition - player.position) * settings.mouseFollowRatio;
        
        // make sure the camera does not exceed maximum lookahead amount
        transform.position = player.position + 
            (cameraPosition.magnitude > settings.maxLookAhead ? 
            cameraPosition.normalized * settings.maxLookAhead :
            cameraPosition);
            
    }
}