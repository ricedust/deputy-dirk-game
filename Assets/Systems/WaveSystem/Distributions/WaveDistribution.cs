using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "WaveDistribution")]
public class WaveDistribution : ScriptableObject {
    [field: SerializeField] public PoolWeight[] types { get; private set; } 

    private int[] cumulativeWeights;

    private void OnEnable() {

        // compute the cumulative sum of each type
        cumulativeWeights = new int[types.Length];

        cumulativeWeights[0] = types[0].weight;
        for (int i = 1; i < types.Length; i++) {
            cumulativeWeights[i] = cumulativeWeights[i - 1] + types[i].weight;
        }
    }
    
    /// <summary>
    /// Returns an instance according to the wave's weighted distribution.
    /// </summary>
    /// <returns></returns>
    public GameObject GetEnemy() {
        // pick a random number in [0, sum of all weights)
        int rand = Random.Range(0, cumulativeWeights[^1]);
        
        // find the type with the cumulative weight that is greater than the random number
        for (int i = 0; i < cumulativeWeights.Length; i++) {
            if (rand < cumulativeWeights[i]) return types[i].pool.Get();
        }
        
        // this return path is not possible but let's use the first type as default
        return types[0].pool.Get();
    }
}

[Serializable]
public struct PoolWeight {

    public PoolWeight(Pool pool, int weight) {
        this.pool = pool;
        this.weight = weight;
    }

    [field: SerializeField] public Pool pool { get; private set; }
    [field: SerializeField] public int weight { get; private set; }
}