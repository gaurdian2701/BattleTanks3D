using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] private PlayerTankView tankView;
    [SerializeField] private List<PlayerTankScriptableObject> playerTanks;
    [SerializeField] private PoolServiceScriptableObject poolServiceScriptableObject;
    [SerializeField] private EnemyWaveServiceScriptableObject enemyWaveServiceScriptableObject;
    [SerializeField] private PlayerTankScriptableObject playerTankSO;
    public EventService EventService { get; private set; }
    public PlayerTankSpawnService PlayerTankSpawnService { get; private set; }
    public PoolService PoolService { get; private set; }
    public EnemyWaveService EnemyWaveService { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        EventService = new EventService();
        PlayerTankSpawnService = new PlayerTankSpawnService(playerTanks, tankView, playerTankSO);
        PoolService = new PoolService(poolServiceScriptableObject);
        EnemyWaveService = new EnemyWaveService(enemyWaveServiceScriptableObject);
    }
}
