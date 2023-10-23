using System.Collections;
using UnityEngine;

public class ExpireToPool : MonoBehaviour {
    [SerializeField] private Pool pool;
    [SerializeField] private float expirationSeconds;

    private void OnEnable() {
        StartCoroutine(Expire());
    }

    private IEnumerator Expire() {
        yield return new WaitForSeconds(expirationSeconds);
        pool.Release(gameObject);
    }
}