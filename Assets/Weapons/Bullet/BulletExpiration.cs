using System.Collections;
using UnityEngine;

public class BulletExpiration : MonoBehaviour {
    [SerializeField] private Pool bulletPool;
    [SerializeField] private float expirationSeconds;

    private void OnEnable() {
        StartCoroutine(Expire());
    }

    private IEnumerator Expire() {
        yield return new WaitForSeconds(expirationSeconds);
        bulletPool.Release(gameObject);
    }
}