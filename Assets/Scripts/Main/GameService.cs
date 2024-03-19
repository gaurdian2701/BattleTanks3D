using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] private TankView tankView;
    [SerializeField] private List<Tank> tankList = new List<Tank>();
    public EventService EventService { get; private set; }
    public PlayerTankSpawnService PlayerTankSpawnService { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        EventService = new EventService();
        PlayerTankSpawnService = new PlayerTankSpawnService(tankList, tankView);
    }
}

[Serializable]
public class Tank
{
    public float movementSpeed;
    public float rotationSpeed;
    public TankType tankType;
    public Material tankColor;
}
