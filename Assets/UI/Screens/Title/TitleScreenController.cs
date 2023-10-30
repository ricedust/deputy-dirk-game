using DG.Tweening;
using UnityEngine;

public class TitleScreenController : MonoBehaviour {
    [SerializeField] private InputReader input;
    [SerializeField] private UIData ui;
    [SerializeField] private ButtonClicker startButton;
    [SerializeField] private GameObject controlsScreen;
    [SerializeField] private float transitionSeconds;

    private void OnEnable() {
        input.EnableUI();
        startButton.onClick += Advance;
    }
    private void OnDisable() {
        startButton.onClick -= Advance;
    }

    private void Advance() {

        input.DisableUI();
        
        transform.DOMoveY(-1080f, transitionSeconds).SetEase(Ease.InOutExpo)
            .OnComplete(() => input.EnableUI())
            .Play();

        if (!ui.hasShownControls) {
            controlsScreen.SetActive(true);
            return;
        }

        ui.RaiseOnPlay();
    }
}