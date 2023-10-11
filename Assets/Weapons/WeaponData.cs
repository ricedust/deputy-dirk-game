using UnityEngine;

[CreateAssetMenu(menuName = "WeaponData")]
public class WeaponData : ScriptableObject {
    [field: SerializeField] public float muzzleVelocity;
    [field: SerializeField] public float kickDistance;
    [field: SerializeField] public float kickRecoverySeconds;
}