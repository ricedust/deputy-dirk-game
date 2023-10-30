using UnityEngine;

[CreateAssetMenu(menuName = "EnemySettings")]
public class EnemySettings : ScriptableObject {
    [field: SerializeField] public float moveForce { get; private set; }
    [field: SerializeField] public float moveVariation { get; private set; }
    [field: SerializeField] public AvoidSettings avoider { get; private set; }
}