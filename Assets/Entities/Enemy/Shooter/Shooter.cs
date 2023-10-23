using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour {
    [SerializeField] private WeaponAiming aiming;
    [SerializeField] private WeaponFiring firing;
    [SerializeField] private PlayerData player;
    [SerializeField] private GameTick tick;
    [SerializeField] private ShooterSettings settings;

    private void OnEnable() {
        tick.onTick += AttemptToShoot;
    }
    private void OnDisable() {
        tick.onTick -= AttemptToShoot;
    }

    private void Update() {
        aiming.AimAt(player.position);
    }

    private void AttemptToShoot()
    {
        if (Random.value > settings.shooter.shootChance) return;
        if ((player.position - (Vector2)transform.position).magnitude > settings.shooter.range) return;
        firing.Fire();
    }
}

[Serializable]
public struct ShootSettings {
    /// <summary>
    /// The likelihood of shooting each game tick.
    /// </summary>
    [field: SerializeField] public float shootChance { get; private set; }
    /// <summary>
    /// The distance from the target required to shoot.
    /// </summary>
    [field: SerializeField] public float range { get; private set; }
}