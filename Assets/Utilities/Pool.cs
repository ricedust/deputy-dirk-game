using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(menuName = "Pool")]
public class Pool : ScriptableObject {
    [SerializeField] private GameObject prefab;
    [SerializeField] private int defaultCapacity;
    [SerializeField] private int maxCapacity;
    public IObjectPool<GameObject> pool { get; private set; }

    private void OnEnable() {
        pool = new ObjectPool<GameObject>(
            () => Instantiate(prefab), 
            (gameObject) => gameObject.SetActive(true),
            (gameObject) => gameObject.SetActive(false),
            (gameObject) => Destroy(gameObject),
            false, defaultCapacity, maxCapacity
        );
    }

    public GameObject Get() => pool.Get();
    public void Release(GameObject gameObject) => pool.Release(gameObject);
}