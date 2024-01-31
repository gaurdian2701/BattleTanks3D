using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel
{
    private EnemyTankController enemyTankController;

    public EnemyTankType tankType;
    public Material tankColor;
    public float movementSpeed;
    public float tankHealth;
    public float damageDealt;
    public EnemyTankModel(EnemyTankScriptableObject enemyTankSO)
    {
        InitializeValues(enemyTankSO);
    }

    private void InitializeValues(EnemyTankScriptableObject enemyTankSO)
    {
        tankType = enemyTankSO.tankType;
        tankColor = enemyTankSO.tankColor;
        movementSpeed = enemyTankSO.movementSpeed;
        tankHealth = enemyTankSO.tankHealth;
        damageDealt = enemyTankSO.damageDealt;
    }

    public void SetEnemyTankController(EnemyTankController _enemyTankController) { enemyTankController = _enemyTankController; }
}
