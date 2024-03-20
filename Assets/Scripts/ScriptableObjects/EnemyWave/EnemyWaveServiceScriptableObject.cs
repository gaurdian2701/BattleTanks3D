using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveService", menuName = "ScriptableObjects/NewEnemyWaveService")]
public class EnemyWaveServiceScriptableObject : ScriptableObject
{
    public EnemyTankView EnemyTankView;
    public List<EnemyWaveScriptableObject> EnemyWaves;
}
