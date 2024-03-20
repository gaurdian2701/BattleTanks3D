using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : GenericObjectPool<BulletController>
{
    private BulletView bulletPrefab;
    public BulletPool(BulletPoolScriptableObject BulletPoolSO)
    {
        bulletPrefab = BulletPoolSO.BulletPrefab;
    }

    public BulletController GetBullet<T>() where T : BulletController
    {
        return GetItemFromPool<T>();
    }

    protected override BulletController CreateItem<U>()
    {
        if (typeof(U) == typeof(ArmourPiercingBulletController))
            return new ArmourPiercingBulletController(bulletPrefab);
        else if (typeof(U) == typeof(HighExplosiveBulletController))
            return new HighExplosiveBulletController(bulletPrefab);
        else if (typeof(U) == typeof(HomingBulletController))
            return new HomingBulletController(bulletPrefab);
        else
            return new ArmourPiercingBulletController(bulletPrefab);
    }
}

public class BulletData
{
    public BulletModel BulletModel;
    public Transform FirePos;

    public BulletData(BulletModel BulletModel, Transform FirePos)
    {
        this.BulletModel = BulletModel;
        this.FirePos = FirePos;
    }
}