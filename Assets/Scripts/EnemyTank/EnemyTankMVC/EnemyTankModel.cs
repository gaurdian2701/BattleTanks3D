using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel
{
    public EnemyTankType tankType;
    public Material tankColor;
    public float movementSpeed;
    public float tankHealth;
    public float damageDealt;
    public Vector3 spawnPosition;
    public EnemyTankModel(EnemyTankScriptableObject enemyTankSO, Vector3 spawnPosition)
    {
        this.spawnPosition = spawnPosition;
        InitializeTankInfo(enemyTankSO);
    }

    private void InitializeTankInfo(EnemyTankScriptableObject enemyTankSO)
    {
        tankType = enemyTankSO.tankType;
        tankColor = enemyTankSO.tankColor;
        movementSpeed = enemyTankSO.movementSpeed;
        tankHealth = enemyTankSO.tankHealth;
        damageDealt = enemyTankSO.damageDealt;
    }
}
