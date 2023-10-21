using UnityEngine;

[CreateAssetMenu(menuName = "BulletSettings")]
public class BulletSettings : ScriptableObject {

    [field: SerializeField] public float speed { get; private set; }
    [field: SerializeField] public int bounces { get; private set; }
    [field: SerializeField] public bool isPiercing { get; private set; }
}