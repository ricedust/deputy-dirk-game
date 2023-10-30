using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PunchIn : MonoBehaviour {
    [SerializeField] private float punchSeconds; 
    [SerializeField] private float delaySeconds;
    private IEnumerator Start() {
        yield return new WaitForEndOfFrame();
        transform.DOScale(Vector2.zero, punchSeconds)
            .From()
            .SetDelay(delaySeconds)
            .SetEase(Ease.OutElastic)
            .Play();
    }
}