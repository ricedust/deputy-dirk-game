using System;
using UnityEngine;

public class Chaser : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform chasePoint;
    [SerializeField] private EnemySettings settings;
    private void FixedUpdate() {

        Vector2 chaseDirection = ((Vector2)chasePoint.position - rigidBody.position).normalized;
        rigidBody.AddForce(chaseDirection * settings.moveForce * Time.fixedDeltaTime);
    }
}