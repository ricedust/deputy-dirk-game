using UnityEngine;

[CreateAssetMenu(menuName = "StickerFlipSettings")]
public class StickerFlipSettings : ScriptableObject {
    [field: SerializeField] public float velocityThreshold;
    [field: SerializeField] public float flipSeconds;
}