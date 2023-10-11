using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData")]
public class PlayerData : ScriptableObject {
    [field:SerializeField] public float moveForce { get; private set; }
    [field:SerializeField] public float rollForce { get; private set; }
    [field:SerializeField] public float rollDurationSeconds { get; private set; }
    [field:SerializeField] public float recoilImpulse { get; private set; }
}