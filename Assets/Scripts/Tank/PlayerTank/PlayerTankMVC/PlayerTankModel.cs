using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankModel
{
    private PlayerTankController tankController;

    public float movementSpeed;
    public float rotationSpeed;
    public PlayerTankClass tankType;
    public Material tankColor;

    public PlayerTankModel(float _movementSpeed, float _rotationSpeed, PlayerTankClass _tankType, Material _tankColor) 
    { 
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
        tankType = _tankType;
        tankColor = _tankColor;
    }
    public void SetTankController(PlayerTankController _tankController)
    {
        tankController = _tankController;
    }
}
