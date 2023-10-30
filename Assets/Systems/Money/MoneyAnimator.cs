using DG.Tweening;
using UnityEngine;

public class MoneyAnimator : MonoBehaviour {
    [SerializeField] private TreasuryData treasury;
    [SerializeField] private float tweenSeconds;

    private Tween popInTween, popOutTween;

    private void Awake() {
        popInTween = transform.DOScale(1f, tweenSeconds)
            .SetEase(Ease.OutBack)
            .SetAutoKill(false)
            .OnPlay(() => { popOutTween.Pause(); }
        );
        popOutTween = transform.DOScale(0f, tweenSeconds)
            .SetEase(Ease.InBack)
            .SetAutoKill(false)
            .OnPlay(() => { popInTween.Pause(); }
        );
    }

    private void OnDestroy() {
        popInTween.Kill();
        popOutTween.Kill();
    }

    private void OnEnable() {
        treasury.onStolen += PopOut;
        treasury.onReturned += PopIn;
    }
    private void OnDisable() {
        treasury.onStolen -= PopOut;
        treasury.onReturned -= PopIn;
    }

    public void PopIn(GameObject pile) {
        if (gameObject != pile) return;
        popInTween.Restart();
    }
    public void PopOut(GameObject pile) {
        if (gameObject != pile) return;
        popOutTween.Restart();
    }
}