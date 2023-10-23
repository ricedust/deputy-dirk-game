using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextPulser : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private float loopSeconds;
    private Tween pulse;

    private void OnEnable() {
        pulse = DOTween.To(
            () => textMesh.alpha, 
            alpha => textMesh.alpha = alpha, 
            0f, loopSeconds / 2
        )
        .SetEase(Ease.InOutSine)
        .SetLoops(-1, LoopType.Yoyo)
        .SetAutoKill(false)
        .Play();
    }

    private void OnDisable() {
        pulse.Kill();
    }
}