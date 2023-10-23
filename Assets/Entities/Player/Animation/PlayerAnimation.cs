using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private InputReader input;
    [SerializeField] private PlayerData dataChannel;

    private static readonly int idle = Animator.StringToHash("PlayerIdle");
    private static readonly int run = Animator.StringToHash("PlayerRun");
    private static readonly int roll = Animator.StringToHash("PlayerRoll");
    private int currentState;

    private void OnEnable() {
        dataChannel.onRoll += Roll;
    }

    private void OnDisable() {
        dataChannel.onRoll -= Roll;
    }

    /// <summary>
    /// Change the animation state if it is not the same as the current one.
    /// </summary>
    /// <param name="newState">The state to change to.</param>
    private void ChangeState(int newState) {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    private void Roll() {
        animator.Play(roll, 0, 0);
        currentState = roll;
    }

    private void LateUpdate() {

        if (IsRolling()) return;

        int state = input.move.ReadValue<Vector2>().magnitude > 0 ? run : idle;
        ChangeState(state);
    }

    private bool IsRolling() {
        return currentState == roll &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f;
    }
}