using UnityEngine;

public class PlayerLife : MonoBehaviour {
    [SerializeField] private BulletReceiver bulletReceiver;
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private PlayerData data;
    private int livesRemaining;

    private void OnEnable() {
        livesRemaining = settings.lives;
        bulletReceiver.onHit += LoseLife;
    }

    private void OnDisable() {
        bulletReceiver.onHit -= LoseLife;
    }

    private void LoseLife()
    {
        if (livesRemaining > 0) {
            livesRemaining--;
            data.RaiseLifeUpdate(livesRemaining);
        }
    }
}