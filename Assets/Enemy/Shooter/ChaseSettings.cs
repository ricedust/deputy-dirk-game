using UnityEngine;

[CreateAssetMenu(menuName = "ChaserSettings")]
public class ChaseSettings : ScriptableObject {
    [field: SerializeField] public float chaseForce { get; private set; } 
    [field: SerializeField] public float strafeSpeed { get; private set; } 
    [field: SerializeField] public float minChaseRadius { get; private set; }
    [field: SerializeField] public float maxChaseRadius { get; private set; }
    [field: SerializeField] public float trackingDamping { get; private set; }
    
}