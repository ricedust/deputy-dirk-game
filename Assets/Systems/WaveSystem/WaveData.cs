using System;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveData")]
public class WaveData : ScriptableObject {

    public event Action<int> onWaveComplete;
    public event Action<int> onWaveStart;

    public void RaiseOnWaveComplete(int wave) => onWaveComplete?.Invoke(wave);
    public void RaiseOnWaveStart(int wave) => onWaveStart?.Invoke(wave);
}