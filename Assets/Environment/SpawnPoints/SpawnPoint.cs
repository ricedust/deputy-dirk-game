using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    [SerializeField] private SpawnPointData spawn;
    private void Start() {
        spawn.points.Add(transform);
    }
}