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

    public void CreateTank(TankType type)
    {
        int tank = (int)type;
        TankModel tankModel = new TankModel(tankList[tank].movementSpeed, tankList[tank].rotationSpeed, tankList[tank].tankType, tankList[tank].tankColor);
        TankController tankController = new TankController(tankView, tankModel);
    }
}
