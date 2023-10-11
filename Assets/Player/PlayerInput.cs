using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour {
    private PlayerInputActions playerInputActions;
    public InputAction move { get; private set; }
    public InputAction aim { get; private set; }
    public InputAction shoot { get; private set; }
    public InputAction roll { get; private set; }

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        move = playerInputActions.player.move;
        aim = playerInputActions.player.aim;
        shoot = playerInputActions.player.shoot;
        roll = playerInputActions.player.roll;
    }

    private void OnEnable() {
        playerInputActions.Enable();
    }
    
    private void OnDisable() {
        playerInputActions.Disable();
    }
}