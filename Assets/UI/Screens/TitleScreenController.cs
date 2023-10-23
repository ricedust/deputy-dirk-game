using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleScreenController : MonoBehaviour {
    [SerializeField] private InputReader input;
    [SerializeField] private UIData ui;
    [SerializeField] private GameObject controlsScreen;
    [SerializeField] private float punchMagnitude;
    [SerializeField] private float punchSeconds; 
    [SerializeField] private float transitionSeconds;

    private void OnEnable() {
        input.EnableUI();
        transform.DOPunchScale(Vector2.one * punchMagnitude, punchSeconds).Play();
        input.play.performed += Advance;
    }
    private void OnDisable() {
        input.play.performed -= Advance;
    }

    private void Advance(InputAction.CallbackContext context) {

        input.DisableUI();
        transform.DOScale(0f, transitionSeconds).SetEase(Ease.InBack).Play();

        if (!ui.hasShownControls) {
            controlsScreen.SetActive(true);
            return;
        }

        ui.RaiseOnPlay();
    }
}