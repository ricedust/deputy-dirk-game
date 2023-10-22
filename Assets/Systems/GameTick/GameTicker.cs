using System.Collections;
using UnityEngine;

public class GameTicker : MonoBehaviour {
    [SerializeField] private GameTick tick;
    private IEnumerator Start() {
        while(true) {
            yield return new WaitForSeconds(tick.ticksPerSecond);
            tick.RaiseTick();
        }
    }
}