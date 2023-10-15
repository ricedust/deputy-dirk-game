using UnityEngine;

[CreateAssetMenu(menuName = "MouseFollowerSettings")]
public class MouseFollowerSettings : ScriptableObject {
    [field: SerializeField] public float maxLookAhead { get; private set; }
    [field: SerializeField] public float mouseFollowRatio { get; private set; }
}