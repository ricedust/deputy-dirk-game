using System;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerChannel")]
public class PlayerChannel : ScriptableObject {
    [field: SerializeField] public Vector2 position { get; private set; }
    public event Action onRoll;

    public void UpdatePosition(Vector2 newPosition) => position = newPosition;
    public void InvokeOnRoll() => onRoll?.Invoke();
}