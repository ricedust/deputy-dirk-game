using System;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData")]
public class PlayerData : ScriptableObject {
    [field: SerializeField] public Vector2 position { get; private set; }
    public event Action<int> onUpdateLives;
    public event Action onRoll;
    public event Action onDeath;

    public void UpdatePosition(Vector2 newPosition) => position = newPosition;
    public void RaiseLifeUpdate(int lives) => onUpdateLives?.Invoke(lives);
    public void RaiseOnRoll() => onRoll?.Invoke();
    public void RaiseOnDeath() => onDeath?.Invoke();
}