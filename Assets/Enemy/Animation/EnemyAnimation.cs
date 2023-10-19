using UnityEngine;

public class EnemyAnimation : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private EnemyDeath enemyDeath;
    [SerializeField] private float runVelocityThreshold;
    private static readonly int idle = Animator.StringToHash("EnemyIdle");
    private static readonly int run = Animator.StringToHash("EnemyRun");
    private static readonly int death = Animator.StringToHash("EnemyDeath");
    private int currentState;
    
    private void OnEnable() {
        enemyDeath.onDeath += PlayDeath;
    }

    private void OnDisable() {
        enemyDeath.onDeath -= PlayDeath;
    }

    private void ChangeState(int newState) {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    private void LateUpdate() {
        if (currentState == death)  return;

        int state = rigidBody.velocity.magnitude > runVelocityThreshold ? run : idle;
        ChangeState(state);
    }

    private void PlayDeath() {
        ChangeState(death);
        Debug.Log("death detected");
    }
}