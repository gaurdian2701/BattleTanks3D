using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankSpawnService
{
    private List<Tank> tankList;
    private PlayerTankView tankView;
    public PlayerTankSpawnService(List<Tank> tankList, PlayerTankView tankView) 
    {
        this.tankList = tankList;
        this.tankView = tankView;
    }

    public void CreateTank(PlayerTankClass type)
    {
        int tank = (int)type;
        PlayerTankModel tankModel = new PlayerTankModel(tankList[tank].movementSpeed, tankList[tank].rotationSpeed, tankList[tank].tankType, tankList[tank].tankColor);
        PlayerTankController tankController = new PlayerTankController(tankView, tankModel);
        GameService.Instance.EventService.OnPlayerSpawned?.Invoke();
    }
}
