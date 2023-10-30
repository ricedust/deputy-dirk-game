using UnityEngine;

public class Bagger : MonoBehaviour {
    [SerializeField] private Stealer stealer;
    [SerializeField] private EnemyDeath death;
    [SerializeField] private TreasuryData treasury; 

    private GameObject inPossession; 

    private void OnEnable() {
        stealer.onStolen += Bag;
        death.onDeath += Return;
    }

    private void OnDisable() {
        stealer.onStolen -= Bag;
        death.onDeath -= Return;
        
        if (inPossession != null) {
            treasury.Lose();
            inPossession = null;    
        }
    }

    private void Bag() {
        if (treasury.count == 0) return;
        inPossession = treasury.Steal();
    }

    private void Return() {
        if (inPossession == null) return;
        treasury.Return(inPossession);
        inPossession = null;
    }
}