using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "TreasuryData")]
public class TreasuryData : ScriptableObject {
    [field: SerializeField] public Vector2 location { get; private set; }
    
    private List<GameObject> remainingPiles;
    public int count => remainingPiles.Count;
    public event Action<GameObject> onStolen;
    public event Action<GameObject> onReturned; 
    public event Action onBankrupt;

    private void OnEnable() {
        remainingPiles = new();
        SceneManager.activeSceneChanged += ResetTreasury;
    }
    private void OnDisable() {
        SceneManager.activeSceneChanged -= ResetTreasury;
    }
    private void ResetTreasury(Scene arg0, Scene arg1) {
        remainingPiles.Clear();
    }

    /// <summary>Initialize treasury data with the money piles.</summary>
    /// <param name="moneyPiles">The money pile game objects to use.</param>
    public void Initialize(Vector2 location, List<GameObject> moneyPiles) {
        this.location = location;
        remainingPiles.AddRange(moneyPiles);
    }

    /// <returns>The stolen money pile.</returns>
    public GameObject Steal() {
        GameObject randomPile = remainingPiles[Random.Range(0, remainingPiles.Count)];
        remainingPiles.Remove(randomPile);
        onStolen?.Invoke(randomPile);
        return randomPile;
    }

    /// <summary>Returns the money pile to the treasury.</summary>
    public void Return(GameObject moneyPile) {
        remainingPiles.Add(moneyPile);
        onReturned?.Invoke(moneyPile);
    }

    /// <summary>Notify that a pile has been permanently lost.</summary>
    public void Lose() {
        if (count > 0) return;
        onBankrupt?.Invoke();
    }
}