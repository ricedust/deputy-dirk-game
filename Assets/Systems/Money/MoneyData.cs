using UnityEngine;

[CreateAssetMenu(menuName = "MoneyData")]
public class MoneyData : ScriptableObject {
    [field: SerializeField] public Vector2 location { get; private set; }
}