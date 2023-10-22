using System;
using UnityEngine;

[CreateAssetMenu(menuName = "GameTick")]
public class GameTick : ScriptableObject {
    
    [field: SerializeField] public float ticksPerSecond { get; private set; }
    public event Action onTick;

    public void RaiseTick() => onTick?.Invoke();
}