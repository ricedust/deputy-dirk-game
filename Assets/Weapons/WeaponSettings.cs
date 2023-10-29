using UnityEngine;

[CreateAssetMenu(menuName = "WeaponSettings")]
public class WeaponSettings : ScriptableObject {
    [field: SerializeField] public float recoilImpulse { get; private set; }
    [field: SerializeField] public float kickDistance { get; private set; }
    [field: SerializeField] public float kickRecoverySeconds { get; private set; }
    [field: SerializeField] public float cooldownSeconds { get; private set; }
    [field: SerializeField] public float cameraShakeMagnitude  { get; private set; }
    [field: SerializeField] public AudioCue sound  { get; private set; }
    [field: SerializeField] public BulletSettings bullet { get; private set; }
    [field: SerializeField] public FiringPattern firingPattern { get; private set; }
}