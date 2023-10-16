using UnityEngine;

public class EnemyAnimation : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float runVelocityThreshold;
    private static readonly int idle = Animator.StringToHash("EnemyIdle");
    private static readonly int run = Animator.StringToHash("EnemyRun");
    private int currentState;
    private void ChangeState(int newState) {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    private void LateUpdate() {
        int state = rigidBody.velocity.magnitude > runVelocityThreshold ? run : idle;
        ChangeState(state);
    }
}