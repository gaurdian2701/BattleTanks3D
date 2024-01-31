using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveScriptableObject", menuName = "ScriptableObjects/NewEnemyWave")]
public class EnemyWaveScriptableObject : ScriptableObject
{
    public int enemyNumber;
    public List<EnemyTankType> enemyTypes;
}
