using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankSpawnService
{
    private List<PlayerTankScriptableObject> tankList;
    private PlayerTankView tankView;
    private PlayerTankScriptableObject tankScriptableObject;
    public PlayerTankSpawnService(List<PlayerTankScriptableObject> tankList, PlayerTankView tankView, PlayerTankScriptableObject playerTankSO) 
    {
        this.tankList = tankList;
        this.tankView = tankView;
        tankScriptableObject = playerTankSO;
    }

    public void CreateTank(PlayerTankClass type)
    {
        int tank = (int)type;
        PlayerTankModel tankModel = new PlayerTankModel( 
            tankList[tank].MaxSpeed,
            tankList[tank].Acceleration,
            tankList[tank].RotationSpeed, 
            tankList[tank].PlayerTankClass, 
            tankList[tank].PlayerTankColor);
        PlayerTankController tankController = new PlayerTankController(tankView, tankModel);
        GameService.Instance.EventService.InvokePlayerSpawnedEvent();
    }
}
