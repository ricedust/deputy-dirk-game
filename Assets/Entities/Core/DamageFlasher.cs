using System.Collections;
using UnityEngine;

public class DamageFlasher : MonoBehaviour {
    [SerializeField] private BulletReceiver bulletReceiver;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private DamageFlashSettings settings;
    private Coroutine flashRed;

    private void OnEnable() {
        sprite.color = Color.white;
        bulletReceiver.onHit += StartFlash;
    }

    private void OnDisable() {
        bulletReceiver.onHit -= StartFlash;
    }

    private void StartFlash() {
        if (flashRed != null) StopCoroutine(flashRed);
        flashRed = StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed() {
        sprite.color = settings.flashColor;
        yield return new WaitForSeconds(settings.flashSeconds);
        sprite.color = Color.white;
    }
}