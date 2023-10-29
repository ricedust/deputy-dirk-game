using UnityEngine;

[CreateAssetMenu(menuName = "AudioChannel")]
public class AudioChannel : ScriptableObject {
    [SerializeField] private Pool audioPool;

    /// <summary>Plays an audio cue at a given location.</summary>
    /// <param name="audioCue">The audio cue to play.</param>
    /// <param name="location">The location the audio source should be placed.</param>
    public void PlayAudioCue(AudioCue audioCue, Vector2 location) {
        GameObject audioInstance = audioPool.Get();
        audioInstance.transform.position = location;
        AudioSource source = InitAudioSource(audioInstance, audioCue);
        source.Play();
    }

    /// <summary>Plays an audio cue at (0,0).</summary>
    /// <param name="audioCue">The auidio cue to play.</param>
    public void PlayAudioCue(AudioCue audioCue) {
        PlayAudioCue(audioCue, Vector2.zero);
    }

    private AudioSource InitAudioSource(GameObject audioInstance, AudioCue cue) {
        AudioSource source = audioInstance.GetComponent<AudioSource>();
        source.clip = cue.clip;
        source.volume = cue.volume;
        source.loop = cue.isLoop;
        source.spatialBlend = cue.isSpatial ? 1 : 0;
        return source;
    }
}