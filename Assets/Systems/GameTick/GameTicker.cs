using System.Collections;
using UnityEngine;

public class GameTicker : MonoBehaviour {
    [SerializeField] private GameTick tick;
    private IEnumerator Start() {
        var waitForSeconds = new WaitForSeconds(tick.ticksPerSecond);
        while(true) {
            yield return waitForSeconds;
            tick.RaiseTick();
        }
    }
}