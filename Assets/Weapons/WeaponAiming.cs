using UnityEngine;

public class WeaponAiming : MonoBehaviour {

    /// <summary>
    /// The direction the weapon is being aimed.
    /// </summary>
    public Vector2 direction { get; private set; }
    /// <summary>
    /// The rotation in the direction of aim.
    /// </summary>
    public Quaternion rotation { get; private set; }

    public void FromTo(Vector2 origin, Vector2 target) {
        direction = target - origin;
        rotation = Quaternion.FromToRotation(Vector2.right, direction);
    }
}