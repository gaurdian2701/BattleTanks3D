using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel
{
    public EnemyTankType TankType;
    public Material TankColor;
    public float MovementSpeed;
    public float TankHealth;
    public float DamageDealt;
    public Vector3 SpawnPosition;
    public BulletScriptableObject BulletSO;
    public Transform fireTransform;

    public EnemyTankModel(EnemyTankScriptableObject enemyTankSO, Vector3 spawnPosition, BulletScriptableObject BulletSO)
    {
        this.SpawnPosition = spawnPosition;
        this.BulletSO = BulletSO;
        InitializeTankInfo(enemyTankSO);
    }

    private void InitializeTankInfo(EnemyTankScriptableObject enemyTankSO)
    {
        TankType = enemyTankSO.TankType;
        TankColor = enemyTankSO.TankColor;
        MovementSpeed = enemyTankSO.MovementSpeed;
        TankHealth = enemyTankSO.TankHealth;
        DamageDealt = enemyTankSO.DamageDealt;
    }
}
