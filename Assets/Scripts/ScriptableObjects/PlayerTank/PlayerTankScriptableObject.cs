using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTankScriptableObject", menuName = "ScriptableObjects/NewPlayerTank")]
public class PlayerTankScriptableObject : ScriptableObject
{
    public float MaxSpeed;
    public float Acceleration;
    public float RotationSpeed;
    public Material PlayerTankColor;
    public PlayerTankClass PlayerTankClass;
}
