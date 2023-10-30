using UnityEngine;

[CreateAssetMenu(menuName = "ThiefSettings")]
public class ThiefSettings : EnemySettings {
    [field: SerializeField] public StealSettings steal { get; private set; }
}