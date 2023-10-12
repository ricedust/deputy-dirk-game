using System;
using UnityEngine;

/// <summary>
/// Controls a focus point that drifts in the mouse direction.
/// </summary>
public class MouseFollow : MonoBehaviour {
    
    [SerializeField] private MouseFollowSetting setting;
    [SerializeField] private Transform player;
    [SerializeField] private PlayerInput input;
    private Camera cam;

    private void Awake() {
        cam = Camera.main;
    }

    private void Update() {
        // find where the camera should be relative to the player
        Vector2 mousePosition = cam.ScreenToWorldPoint(input.aim.ReadValue<Vector2>());
        Vector2 playerToMouse = mousePosition - (Vector2)player.position;
        Vector2 cameraPosition = playerToMouse * setting.mouseFollowRatio; 
        
        // make sure the camera does not exceed maximum lookahead amount
        transform.localPosition = cameraPosition.magnitude > setting.maxLookAhead ?
            playerToMouse.normalized * setting.maxLookAhead : cameraPosition;
            
    }
}