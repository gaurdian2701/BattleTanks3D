using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventService
{
    public Action OnPlayerSpawned;
    public Action<BattleEventType> OnBattleEventOccurred;
}
