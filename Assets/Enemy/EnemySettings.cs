using UnityEngine;

[CreateAssetMenu(menuName = "EnemySettings")]
public class EnemySettings : ScriptableObject {
    [field: SerializeField] public float moveForce { get; private set; }
    [field: SerializeField] public float avoidRadius { get; private set; }
    [field: SerializeField] public float avoidForce { get; private set; }
}