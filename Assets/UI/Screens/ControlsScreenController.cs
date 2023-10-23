using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsScreenController : MonoBehaviour {
    [SerializeField] private InputReader input;
    [SerializeField] private UIData ui;
    [SerializeField] private float transitionTimeSeconds;

    private void OnEnable() {
        input.EnableUI();
        transform.DOMoveY(1080f, transitionTimeSeconds).SetEase(Ease.OutBack).From().Play();
        input.play.performed += Advance;
    }

    private void OnDisable() {
        input.play.performed -= Advance;
    }

    private void Advance(InputAction.CallbackContext context)
    {
        input.DisableUI();
        transform.DOMoveY(-1080, transitionTimeSeconds).SetEase(Ease.InBack).Play();
        ui.hasShownControls = true;
        ui.RaiseOnPlay();
    }
}