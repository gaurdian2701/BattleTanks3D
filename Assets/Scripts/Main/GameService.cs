using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] private PlayerTankView tankView;
    [SerializeField] private List<Tank> tankList = new List<Tank>();
    [SerializeField] private PoolServiceScriptableObject poolServiceScriptableObject;
    [SerializeField] private EnemyWaveServiceScriptableObject enemyWaveServiceScriptableObject;
    public EventService EventService { get; private set; }
    public PlayerTankSpawnService PlayerTankSpawnService { get; private set; }
    public PoolService PoolService { get; private set; }
    public EnemyWaveService EnemyWaveService { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        EventService = new EventService();
        PlayerTankSpawnService = new PlayerTankSpawnService(tankList, tankView);
        PoolService = new PoolService(poolServiceScriptableObject);
        EnemyWaveService = new EnemyWaveService(enemyWaveServiceScriptableObject);
    }
}

[Serializable]
public class Tank
{
    public float movementSpeed;
    public float rotationSpeed;
    public PlayerTankClass tankType;
    public Material tankColor;
}
