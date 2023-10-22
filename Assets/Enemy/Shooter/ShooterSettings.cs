using UnityEngine;

[CreateAssetMenu(menuName = "ShooterSettings")]
public class ShooterSettings : EnemySettings {
    [field: SerializeField] public ChaseSettings chaser { get; private set; }
    [field: SerializeField] public PauseSettings pauser { get; private set; }
    [field: SerializeField] public ShootSettings shooter { get; private set; }
}