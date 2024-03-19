using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveService : MonoBehaviour
{
    [SerializeField] private EnemyWaveScriptableObject enemyWaveSO;

    private EnemyTankModel enemyTankModel;
    private EnemyTankController enemyTankController;

    private void Awake()
    {
        GameService.Instance.EventService.OnPlayerSpawned += SpawnEnemies;
    }

    private void OnDestroy()
    {
        GameService.Instance.EventService.OnPlayerSpawned -= SpawnEnemies;
    }
    private void SpawnEnemies()
    {
        for(int i = 0; i < enemyWaveSO.EnemyData.Count; i++)
            InstantiateTank(enemyWaveSO.EnemyData[i]);
    }

    private void InstantiateTank(EnemySpawnData EnemyData)
    {
        enemyTankModel = new EnemyTankModel(EnemyData.EnemyTankSO, EnemyData.SpawnPosition);
        enemyTankController = new EnemyTankController(enemyTankModel, enemyWaveSO.EnemyView);
    }
}
