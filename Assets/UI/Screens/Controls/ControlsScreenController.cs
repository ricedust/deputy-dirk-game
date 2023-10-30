using DG.Tweening;
using UnityEngine;

public class ControlsScreenController : MonoBehaviour {
    [SerializeField] private InputReader input;
    [SerializeField] private ButtonClicker startButton;
    [SerializeField] private UIData ui;
    [SerializeField] private float transitionSeconds;

    private void OnEnable() {
        startButton.onClick += Advance;
    }

    private void OnDisable() {
        startButton.onClick -= Advance;
    }

    private void Advance()
    {
        input.DisableUI();
        transform.DOMoveY(-1080f, transitionSeconds).SetEase(Ease.InOutExpo).Play();
        ui.hasShownControls = true;
        ui.RaiseOnPlay();
    }
}