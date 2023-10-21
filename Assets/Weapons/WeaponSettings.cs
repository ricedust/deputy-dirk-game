using UnityEngine;

[CreateAssetMenu(menuName = "WeaponSettings")]
public class WeaponSettings : ScriptableObject {
    [field: SerializeField] public float recoilImpulse;
    [field: SerializeField] public float kickDistance;
    [field: SerializeField] public float kickRecoverySeconds;
    [field: SerializeField] public float cameraShakeMagnitude;
}