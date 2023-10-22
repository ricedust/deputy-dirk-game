using UnityEngine;

public class LaserSightCaster : MonoBehaviour {

    [SerializeField] private LineRenderer line;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float maxDistance;
    private void Awake() {
        line.positionCount = 2;
        line.SetPosition(0, Vector2.zero);
    }
    private void FixedUpdate() {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            transform.TransformDirection(Vector2.right),
            maxDistance, mask
        );
        
        line.SetPosition(1, hit ? 
            transform.InverseTransformPoint(hit.point) : 
            Vector2.right * maxDistance
        );
    }
}