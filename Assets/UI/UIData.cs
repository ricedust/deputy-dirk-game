using System;
using UnityEngine;

[CreateAssetMenu(menuName = "UIData")]
public class UIData : ScriptableObject {
    public event Action OnPlay;
    public bool hasShownControls;
    public void RaiseOnPlay() => OnPlay?.Invoke();
}