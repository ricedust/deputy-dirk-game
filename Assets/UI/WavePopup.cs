using DG.Tweening;
using TMPro;
using UnityEngine;

public class WavePopup : MonoBehaviour {
    [SerializeField] private WaveData wave;
    [SerializeField] private float popupSpeedSeconds;
    [SerializeField] private float popupDurationSeconds;
    [SerializeField] private TextMeshProUGUI textMesh;
    private Sequence popupSequence;
    private const string prefix = "WAVE ";

    private void Awake() {
        transform.localScale = Vector2.zero;

        popupSequence = DOTween.Sequence();
        popupSequence.Append(transform.DOScale(Vector2.one, popupSpeedSeconds).SetEase(Ease.OutBack));
        popupSequence.AppendInterval(popupDurationSeconds);
        popupSequence.Append(transform.DOScale(Vector2.zero, popupSpeedSeconds).SetEase(Ease.InBack));
        popupSequence.SetAutoKill(false);
    }
    private void OnEnable() {
        wave.onWaveStart += StartPopupSequence;
    }

    private void OnDisable() {
        wave.onWaveStart -= StartPopupSequence;
    }

    private void OnDestroy() {
        popupSequence.Kill();
    }

    private void StartPopupSequence(int wave) {
        textMesh.text = prefix + wave;
        popupSequence.Restart();
    }
}