using UnityEngine;

public class PlayerBroadcaster : MonoBehaviour {
    [SerializeField] private PlayerChannel channel;
    [SerializeField] private Collider2D centerMass;
    [SerializeField] private PlayerRoll roll;

    private void OnEnable() {
        roll.onRoll += channel.InvokeOnRoll;
    }

    private void OnDisable() {
        roll.onRoll -= channel.InvokeOnRoll;
    }

    private void Update() {
        channel.UpdatePosition((Vector2)transform.position + centerMass.offset);
    }   
}