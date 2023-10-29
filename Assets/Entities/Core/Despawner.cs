using System.Collections;
using UnityEngine;

public class Despawner : MonoBehaviour {
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private DespawnSettings settings;

    private Coroutine flickerOutRoutine;

    private void OnEnable() {
        sprite.enabled = true;
    }

    public void Despawn(Pool optionalPool = null) {
        if (flickerOutRoutine != null) StopCoroutine(flickerOutRoutine);
        flickerOutRoutine = StartCoroutine(FlickerOut(optionalPool));
    }

    private IEnumerator FlickerOut(Pool optionalPool = null) {
        
        yield return new WaitForSeconds(settings.delaySeconds);
        
        var waitForInterval = new WaitForSeconds(settings.flickerIntervalSeconds);
        for (int i = 0; i < settings.flickerCount; i++) {
            sprite.enabled = false;
            yield return waitForInterval;
            sprite.enabled = true;
            yield return waitForInterval;
        }

        if (optionalPool != null) {
            optionalPool.Release(gameObject);
            yield break;
        }

        Destroy(gameObject);
    }
}