using System.Collections;
using UnityEngine;

public class AudioExpiration : MonoBehaviour {
    [SerializeField] private Pool audioPool;
    [SerializeField] private AudioSource audioSource; 
    private void OnEnable() {
        StartCoroutine(ExpireOnComplete());
    }

    private IEnumerator ExpireOnComplete() {

        // wait for audio source information
        yield return new WaitForEndOfFrame();

        if (audioSource.loop) yield break;

        var waitForSeconds = new WaitForSeconds(audioSource.clip.length);
        yield return waitForSeconds;
        audioPool.Release(gameObject);
    }
}