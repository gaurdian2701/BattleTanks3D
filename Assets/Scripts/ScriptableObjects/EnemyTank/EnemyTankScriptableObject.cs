using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObjects/NewEnemyTank")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public EnemyTankType tankType;
    public Material tankColor;
    public float movementSpeed;
    public float tankHealth;
    public float damageDealt;
}
