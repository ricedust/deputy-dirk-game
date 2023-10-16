using UnityEngine;

public class PlayerBroadcaster : MonoBehaviour {
    [SerializeField] private PlayerChannel channel;
    [SerializeField] private PlayerRoll roll;

    private void OnEnable() {
        roll.onRoll += channel.InvokeOnRoll;
    }

    private void OnDisable() {
        roll.onRoll -= channel.InvokeOnRoll;
    }

    private void Update() {
        channel.UpdatePosition(transform.position);
    }   
}