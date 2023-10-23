using DG.Tweening;
using UnityEngine;

public class LifeIcon : MonoBehaviour {
    // [SerializeField] private Renderer renderer;
    [SerializeField] private float tweenSeconds;
    private Tween popInTween;
    private Tween popOutTween;
    [field: SerializeField] public bool isEnabled { get; private set; } = true;

    private void Awake() {
        popInTween = transform.DOScale(1f, tweenSeconds)
            .SetEase(Ease.OutBack)
            .SetAutoKill(false)
            .OnPlay(() => { isEnabled = true; popOutTween.Pause(); }
        );
        popOutTween = transform.DOScale(0f, tweenSeconds)
            .SetEase(Ease.InBack)
            .SetAutoKill(false)
            .OnPlay(() => { isEnabled = false; popInTween.Pause(); }
        );
    }

    private void OnDestroy() {
        popInTween.Kill();
        popOutTween.Kill();
    }

    public void PopIn() => popInTween.Restart();

    public void PopOut() => popOutTween.Restart();
}