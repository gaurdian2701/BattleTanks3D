using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveScriptableObject", menuName = "ScriptableObjects/NewEnemyWave")]
public class EnemyWaveScriptableObject : ScriptableObject
{
    public List<EnemySpawnData> EnemyData;
}

[Serializable]
public struct EnemySpawnData
{
    public EnemyTankScriptableObject EnemyTankSO;
    public Vector3 SpawnPosition;
}
