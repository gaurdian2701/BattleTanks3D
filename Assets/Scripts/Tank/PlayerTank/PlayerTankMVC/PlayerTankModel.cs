using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankModel
{
    private PlayerTankController tankController;

    public float maxSpeed;
    public float rotationSpeed;
    public int mass;
    public float acceleration;
    public PlayerTankClass tankType;
    public Material tankColor;

    public PlayerTankModel(float _maxSpeed, float _acceleration,float _rotationSpeed, PlayerTankClass _tankType, Material _tankColor) 
    {
        maxSpeed = _maxSpeed;
        acceleration = _acceleration;
        rotationSpeed = _rotationSpeed;
        tankType = _tankType;
        tankColor = _tankColor;
    }
    public void SetTankController(PlayerTankController _tankController)
    {
        tankController = _tankController;
    }
}
