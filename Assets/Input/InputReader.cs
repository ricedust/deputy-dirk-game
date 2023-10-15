using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputReader")]
public class InputReader : ScriptableObject {

    public InputAction move { get; private set; }
    public InputAction aim { get; private set; }
    public InputAction shoot { get; private set; }
    public InputAction roll { get; private set; }
    private InputActions inputActions;

    private void OnEnable() {
        if (inputActions == null) inputActions = new InputActions();
        inputActions.Enable();

        move = inputActions.player.move;
        aim = inputActions.player.aim;
        shoot = inputActions.player.shoot;
        roll = inputActions.player.roll;
    }
}