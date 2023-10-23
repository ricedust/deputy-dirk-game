using UnityEngine;

public class PlayerLife : MonoBehaviour {
    [SerializeField] private BulletReceiver bulletReceiver;
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private WaveData waveData;
    private int livesRemaining;

    private void OnEnable() {
        livesRemaining = settings.lives;
        bulletReceiver.onHit += LoseLife;
        waveData.onWaveStart += RestoreLives;
    }

    private void OnDisable() {
        bulletReceiver.onHit -= LoseLife;
        waveData.onWaveStart -= RestoreLives;
    }

    private void LoseLife()
    {
        if (livesRemaining > 0) {
            livesRemaining--;
            playerData.RaiseLifeUpdate(livesRemaining);
        }
    }

    private void RestoreLives(int _) {
        livesRemaining = settings.lives;
        playerData.RaiseLifeUpdate(livesRemaining);
    }
}