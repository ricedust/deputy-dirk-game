using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoll : MonoBehaviour {

    [SerializeField] private InputReader input;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerSettings settings;
    private float rollForce;
    private Tween rollTween;

    private void Awake() {
        rollTween = DOTween.To(
            () => rollForce, 
            x => rollForce = x, 
            settings.rollForce, 
            settings.rollDurationSeconds / 2
        )
        .SetEase(Ease.OutExpo)
        .SetLoops(2, LoopType.Yoyo)
        .SetAutoKill(false);
    }

    private void OnEnable() {
        input.roll.performed += Roll;
    }

    private void OnDisable() {
        input.roll.performed -= Roll;
    }

    private void FixedUpdate() {
        if (rollForce > 0) {
            Vector2 moveDirection = input.move.ReadValue<Vector2>();
            rigidBody.AddForce(moveDirection * rollForce * Time.fixedDeltaTime);
        }
    }

    private void Roll(InputAction.CallbackContext context) {
        if (!rollTween.IsPlaying()) rollTween.Restart();
    }
}