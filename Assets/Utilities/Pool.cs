using System;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Pool")]
public class Pool : ScriptableObject {
    [SerializeField] private GameObject prefab;
    [SerializeField] private int defaultCapacity;
    [SerializeField] private int maxCapacity;
    public ObjectPool<GameObject> pool { get; private set; }

    private void OnEnable() {
        pool = new ObjectPool<GameObject>(
            () => Instantiate(prefab), 
            (gameObject) => gameObject.SetActive(true),
            (gameObject) => gameObject.SetActive(false),
            (gameObject) => Destroy(gameObject),
            false, defaultCapacity, maxCapacity
        );
        SceneManager.activeSceneChanged += Dispose;
    }

    private void OnDisable() {
        SceneManager.activeSceneChanged -= Dispose;
    }
    private void Dispose(Scene arg0, Scene arg1) => pool.Clear();

    public GameObject Get() => pool.Get();
    public void Release(GameObject gameObject) => pool.Release(gameObject);
    public int CountActive() => pool.CountActive;
}

[Serializable] 
public struct PoolGroup {
    [field: SerializeField] public Pool[] pools { get; private set; }

    public int CountTotalActive() {
        int active = 0;
        Array.ForEach(pools, pool => active += pool.CountActive());
        return active;
    }
}