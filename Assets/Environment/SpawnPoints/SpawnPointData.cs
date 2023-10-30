using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SpawnPointData")]
public class SpawnPointData : ScriptableObject {
    [field: SerializeField] public List<Transform> points { get; private set; }

    private void OnEnable() {
        points = new();
        SceneManager.activeSceneChanged += ResetPoints;
    }

    private void OnDisable() {
        SceneManager.activeSceneChanged -= ResetPoints;
    }

    private void ResetPoints(Scene arg0, Scene arg1) {
        points.Clear();
    }
}