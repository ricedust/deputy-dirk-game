using System;
using UnityEngine;

[Serializable]
public struct BehaviorGroup
{
    [SerializeField] private Behaviour[] behaviours;
    public void SetEnabled(bool isEnabled = true) {
        Array.ForEach(behaviours, behavior => behavior.enabled = isEnabled);
    }
}