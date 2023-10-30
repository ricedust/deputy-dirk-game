using System;
using UnityEngine;

[CreateAssetMenu(menuName = "UIData")]
public class UIData : ScriptableObject {
    [SerializeField] private InputReader input;
    public event Action OnPlay;
    public bool hasShownControls;
    public void RaiseOnPlay() {
        input.EnablePlayer();
        OnPlay?.Invoke();
    }
}