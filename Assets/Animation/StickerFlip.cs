using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipOnX : MonoBehaviour {
    [SerializeField] private InputReader input;
    [SerializeField] private bool useRigidbody;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private StickerFlipSettings settings;
    private Tween flipLeft;
    private Tween flipRight;

    private void OnEnable() {
        flipLeft = transform.DOScaleX(-1, settings.flipSeconds / 2)
            .SetAutoKill(false)
            .SetEase(Ease.OutExpo)
            .OnPlay(() => flipRight.Pause());
        flipRight = transform.DOScaleX(1, settings.flipSeconds / 2)
            .SetAutoKill(false)
            .SetEase(Ease.OutExpo)
            .OnPlay(() => flipLeft.Pause());

        if (useRigidbody) return;
        input.move.performed += FlipOnInput;
    }

    private void OnDisable() {
        flipLeft.Kill();
        flipRight.Kill();

        if (useRigidbody) return;
        input.move.performed -= FlipOnInput;
    }

    private void Flip(float xDirection) {
        if (xDirection < 0 && transform.localScale.x > 0 && !flipLeft.IsPlaying()) {
            flipLeft.Restart();
        }
        else if (xDirection > 0 && transform.localScale.x < 0 && !flipRight.IsPlaying()) {
            flipRight.Restart();
        }
    }

    private void FlipOnInput(InputAction.CallbackContext context)
    {
        Flip(context.ReadValue<Vector2>().x);
    }

    private void FixedUpdate() {
        if (!useRigidbody) return;
        if (Mathf.Abs(rigidBody.velocity.x) < settings.velocityThreshold) return;
        Flip(rigidBody.velocity.x);
    }

}