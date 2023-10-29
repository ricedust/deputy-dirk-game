using System;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioCue")]
public class AudioCue : ScriptableObject {
    [field: SerializeField] public AudioClip clip { get; private set; }
    [field: SerializeField] public float volume { get; private set; }
    [field: SerializeField] public bool isLoop { get; private set; }
    [field: SerializeField] public bool isSpatial { get; private set; }
}