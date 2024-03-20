using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolService
{
    public BulletPool BulletPool {  get; private set; }
    public PoolService(PoolServiceScriptableObject poolServiceSO)
    {
        BulletPool = new BulletPool(poolServiceSO.BulletPoolSO);
    }
}
