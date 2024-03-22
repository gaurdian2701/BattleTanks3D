using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveService
{
    private EnemyWaveServiceScriptableObject enemyWaveServiceSO;
    private EnemyTankModel enemyTankModel;
    private int enemiesLeftInWave;
    private EnemyTankController enemyTankController;

    public EnemyWaveService(EnemyWaveServiceScriptableObject enemyWaveServiceSO)
    {
        this.enemyWaveServiceSO = enemyWaveServiceSO;
        GameService.Instance.EventService.OnPlayerSpawned += InitiateWaves;
    }

    ~EnemyWaveService()
    {
        GameService.Instance.EventService.OnPlayerSpawned -= InitiateWaves;
    }
    private void InitiateWaves()
    {
        StartEnemyWave(enemyWaveServiceSO.EnemyWaves[0]);
    }

    private void StartEnemyWave(EnemyWaveScriptableObject waveSO)
    {
        //other logic for starting wave???
        SpawnEnemies(waveSO);
        enemiesLeftInWave = waveSO.EnemyData.Count;
    }

    private void SpawnEnemies(EnemyWaveScriptableObject waveSO)
    {
        for(int i = 0; i< waveSO.EnemyData.Count; i++)
            InstantiateTank(waveSO.EnemyData[i]);
    }
    private void InstantiateTank(EnemySpawnData EnemyData)
    {
        enemyTankModel = new EnemyTankModel(EnemyData.EnemyTankSO, EnemyData.SpawnPosition, EnemyData.EnemyTankSO.BulletSO);
        enemyTankController = new EnemyTankController(enemyTankModel, enemyWaveServiceSO.EnemyTankView);
    }
}
