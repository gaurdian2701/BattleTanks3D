using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveController : MonoBehaviour
{
    [SerializeField] private EnemyWaveScriptableObject enemyWaveSO;

    [SerializeField] private EnemyTankView tankView;

    [SerializeField] private EnemyTankScriptableObject heavyAssault;
    [SerializeField] private EnemyTankScriptableObject scout;
    [SerializeField] private EnemyTankScriptableObject artillery;

    private int enemyNumber;
    private List<EnemyTankType> enemyTanks;
    private EnemyTankModel enemyTankModel;
    private EnemyTankController enemyTankController;

    private void Awake()
    {
        enemyNumber = enemyWaveSO.enemyNumber;
        enemyTanks = enemyWaveSO.enemyTypes;
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for(int i=0; i < enemyNumber; i++)
        {
            int tankToSpawn = Random.Range(0, enemyTanks.Count);
            InstantiateTank(enemyTanks[tankToSpawn]);
        }
    }

    private void InstantiateTank(EnemyTankType tank)
    {
        switch(tank)
        {
            case EnemyTankType.HeavyAssault:
                enemyTankModel = new EnemyTankModel(heavyAssault); break;

            case EnemyTankType.Scout:
                enemyTankModel = new EnemyTankModel(scout); break;

            case EnemyTankType.Artillery:
                enemyTankModel = new EnemyTankModel(artillery); break;

            default: break;
        }

        enemyTankController = new EnemyTankController(enemyTankModel, tankView, this.transform.position);
    }
}
