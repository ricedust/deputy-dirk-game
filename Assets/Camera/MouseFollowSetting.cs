using UnityEngine;

[CreateAssetMenu(menuName = "MouseFollowSetting")]
public class MouseFollowSetting : ScriptableObject {
    [field: SerializeField] public float maxLookAhead { get; private set; }
    [field: SerializeField] public float mouseFollowRatio { get; private set; }
}