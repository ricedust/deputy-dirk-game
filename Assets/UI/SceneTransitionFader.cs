using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionFader : MonoBehaviour {

    [SerializeField] private Image image;
    [SerializeField] private PlayerData player;
    [SerializeField] private InputReader input;
    [SerializeField] private TreasuryData treasury;
    [SerializeField] private float transitionSeconds;
    private Color original;
    private void OnEnable() {
        original = image.color;
        image.DOColor(new Color(original.r, original.g, original.b, 0), transitionSeconds)
            .SetEase(Ease.InOutSine)
            .Play();

        player.onDeath += FadeOut;
        treasury.onBankrupt += FadeOut;
    }

    private void OnDisable() {
        player.onDeath -= FadeOut;
        treasury.onBankrupt -= FadeOut;
    }

    private void FadeOut() {
        input.DisablePlayer();
        image.DOColor(original, transitionSeconds)
            .OnComplete(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex))
            .SetEase(Ease.InOutSine)
            .Play();
    }
}