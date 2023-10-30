using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private float tweenSeconds;
    [SerializeField] private float buttonGrowth;
    
    private Tween growTween;
    private Tween shrinkTween;
    private void Awake() {
        growTween = transform.DOScale((Vector2)transform.localScale + Vector2.one * buttonGrowth, tweenSeconds)
            .SetEase(Ease.OutElastic)
            .OnPlay(() => shrinkTween.Pause())
            .SetAutoKill(false);
        shrinkTween = transform.DOScale(transform.localScale, tweenSeconds)
            .SetEase(Ease.OutElastic)
            .OnPlay(() => growTween.Pause())
            .SetAutoKill(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.DOPunchScale(Vector2.one * buttonGrowth, tweenSeconds).Play();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        growTween.Restart();
    }

    public void OnPointerExit(PointerEventData eventData) {
        shrinkTween.Restart();
    }

    private void OnDisable() {
        growTween.Kill();
        shrinkTween.Kill();
    }
}