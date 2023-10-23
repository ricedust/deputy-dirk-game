using UnityEngine;

[CreateAssetMenu(menuName = "PlayerSettings")]
public class PlayerSettings : ScriptableObject {
    [field: SerializeField] public int lives { get; private set; }
    [field: SerializeField] public float moveForce { get; private set; }
    [field: SerializeField] public float rollForce { get; private set; }
    [field: SerializeField] public float rollDurationSeconds { get; private set; }
}