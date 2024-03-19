using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankSpawnService
{
    private List<Tank> tankList;
    private TankView tankView;
    public PlayerTankSpawnService(List<Tank> tankList, TankView tankView) 
    {
        this.tankList = tankList;
        this.tankView = tankView;
    }

    public void CreateTank(TankType type)
    {
        int tank = (int)type;
        TankModel tankModel = new TankModel(tankList[tank].movementSpeed, tankList[tank].rotationSpeed, tankList[tank].tankType, tankList[tank].tankColor);
        TankController tankController = new TankController(tankView, tankModel);
        GameService.Instance.EventService.OnPlayerSpawned?.Invoke();
    }
}
