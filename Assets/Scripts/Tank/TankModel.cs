using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;
    public TankType tankType;
    public Material tankColor;

    public TankModel(float _movementSpeed, float _rotationSpeed, TankType _tankType, Material _tankColor) 
    { 
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
        tankType = _tankType;
        tankColor = _tankColor;
    }
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
