using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionFader : MonoBehaviour {

    [SerializeField] private Image image;
    [SerializeField] private PlayerData player;
    [SerializeField] private float transitionSeconds;
    private Color original;
    private void OnEnable() {
        original = image.color;
        image.DOColor(new Color(original.r, original.g, original.b, 0), transitionSeconds)
            .SetEase(Ease.InOutSine)
            .Play();

        player.onDeath += FadeOut;
    }

    private void OnDisable() {
        player.onDeath -= FadeOut;
    }

    private void FadeOut() {
        image.DOColor(original, transitionSeconds)
            .OnComplete(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex))
            .SetEase(Ease.InOutSine)
            .Play();
    }
}