using System;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    [SerializeField] private UIData ui;
    [SerializeField] private AudioCue soundtrack;
    [SerializeField] private AudioChannel audioChannel;

    private void OnEnable() {
        ui.OnPlay += PlaySoundtrack;
    }

    private void OnDisable() {
        ui.OnPlay -= PlaySoundtrack;
    }

    private void PlaySoundtrack()
    {
        audioChannel.PlayAudioCue(soundtrack);
    }
}