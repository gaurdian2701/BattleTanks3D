using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventService
{
    public delegate void PlayerSpawnedDelegate();
    public delegate void OnBattleEventDelegate(BattleEventType battleEventType);

    public event PlayerSpawnedDelegate OnPlayerSpawned;
    public event OnBattleEventDelegate OnBattleEventOccurred;

    public void InvokePlayerSpawnedEvent() => OnPlayerSpawned?.Invoke();
    public void InvokeBattleEventOccurredEvent(BattleEventType battleEventType) => OnBattleEventOccurred?.Invoke(battleEventType);
}
