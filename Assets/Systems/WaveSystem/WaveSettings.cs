using UnityEngine;

[CreateAssetMenu(menuName = "WaveSettings")]
public class WaveSettings : ScriptableObject {
    [field: SerializeField] public WaveDistribution[] distributions { get; private set; } 
}