using UnityEngine;

public class PlayerDeath : MonoBehaviour {
    [SerializeField] private PlayerData player;
    [SerializeField] private Despawner despawner;
    private bool isDead;

    private void OnEnable() {
        isDead = false;
        player.onUpdateLives += Die;
    }
    private void OnDisable() {
        player.onUpdateLives -= Die;
    }

    private void Die(int lives) {
        // ignore if still alive or already dead
        if (lives > 0 || isDead) return;
        isDead = true;
        player.RaiseOnDeath();
        despawner.Despawn();
    }
}