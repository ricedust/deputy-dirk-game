using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pauser : MonoBehaviour {
    [SerializeField] private ShooterSettings settings;
    [SerializeField] private GameTick tick;
    [SerializeField] private BehaviorGroup toDisable;
    private int remainingTicksToPause;

    private void OnEnable() {
        remainingTicksToPause = 0;
        toDisable.SetEnabled(true);
        
        tick.onTick += AttemptPause;
        tick.onTick += TickDownRemaining;
    }

    private void OnDisable() {
        tick.onTick -= AttemptPause;
        tick.onTick -= TickDownRemaining;
    }

    private void AttemptPause()
    {
        // should not pause if already paused
        if (remainingTicksToPause > 0) return;
        // should not pause if chance window is missed
        if (Random.value > settings.pauser.pauseChance) return; 

        remainingTicksToPause = Random.Range(settings.pauser.minPause, settings.pauser.maxPause + 1);
        toDisable.SetEnabled(false);
    }

    private void TickDownRemaining()
    {
        if (remainingTicksToPause == 0) return;

        remainingTicksToPause--;
        if (remainingTicksToPause == 0) toDisable.SetEnabled(true);
    }
}

[Serializable]
public struct PauseSettings {
    /// <summary>
    /// The likelihood of pausing each game tick.
    /// </summary>
    [field: SerializeField] public float pauseChance { get; private set; }
    /// <summary>
    /// The minimum number of ticks to pause for.
    /// </summary>
    [field: SerializeField] public int minPause { get; private set; }
    /// <summary>
    /// The maximum number of ticks to pause for.
    /// </summary>
    [field: SerializeField] public int maxPause { get; private set; } 
}