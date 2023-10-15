using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData")]
public class PlayerData : ScriptableObject {
    [field: SerializeField] public Vector2 position { get; private set; } 
}