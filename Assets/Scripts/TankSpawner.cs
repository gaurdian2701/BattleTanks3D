using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankView;

    [Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float rotationSpeed;
        public TankType tankType;
        public Material tankColor;
    }

    public List<Tank> tankList = new List<Tank>();
    private void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel(tankList[1].movementSpeed, tankList[1].rotationSpeed, tankList[1].tankType, tankList[1].tankColor);
        TankController tankController = new TankController(tankView, tankModel);
    }
}
