using System.Linq;
using UnityEngine;

public class Treasury : MonoBehaviour {
    [SerializeField] private TreasuryData data;
    [SerializeField] private Transform moneyMound;
    [SerializeField] private GameObject[] moneyPiles;

    private void Start() {
        data.Initialize(moneyMound.transform.position, moneyPiles.ToList());
    }
}