using UnityEngine;

public class EnemyDeath : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag.Equals(tag)) return;
    }
}