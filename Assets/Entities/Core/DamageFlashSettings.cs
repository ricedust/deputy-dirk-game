using UnityEngine;

[CreateAssetMenu(menuName = "DamageFlashSettings")]
public class DamageFlashSettings : ScriptableObject {
    [field: SerializeField] public Color flashColor { get; private set; }
    [field: SerializeField] public float flashSeconds { get; private set; }
}