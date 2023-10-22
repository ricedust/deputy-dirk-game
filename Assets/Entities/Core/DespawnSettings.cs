using UnityEngine;

[CreateAssetMenu(menuName = "DespawnSettings")]
public class DespawnSettings : ScriptableObject {
    [field: SerializeField] public float delaySeconds { get; private set; }
    [field: SerializeField] public float flickerIntervalSeconds { get; private set; }
    [field: SerializeField] public int flickerCount { get; private set; }
}