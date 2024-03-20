using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObjects/NewEnemyTank")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public EnemyTankClass TankType;
    public Material TankColor;
    public float MovementSpeed;
    public float TankHealth;
    public float DamageDealt;
    public BulletScriptableObject BulletSO;
}
