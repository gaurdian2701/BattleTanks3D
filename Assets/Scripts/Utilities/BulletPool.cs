using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : GenericObjectPool<BulletController>
{
    private BulletView bulletPrefab;
    private BulletModel bulletModel;
    private Transform firePos;
    public BulletPool(BulletPoolScriptableObject BulletPoolSO)
    {
        bulletPrefab = BulletPoolSO.BulletPrefab;
    }

    public BulletController GetBullet<T>(BulletData bulletData) where T : BulletController
    {
        bulletModel = bulletData.BulletModel;
        firePos = bulletData.FirePos;
        return GetItemFromPool<T>();
    }

    protected override BulletController CreateItem<U>()
    {
        if (typeof(U) == typeof(ArmourPiercingBulletController))
            return new ArmourPiercingBulletController(bulletPrefab, bulletModel, firePos);
        else if (typeof(U) == typeof(HighExplosiveBulletController))
            return new HighExplosiveBulletController(bulletPrefab, bulletModel, firePos);
        else if (typeof(U) == typeof(HomingBulletController))
            return new HomingBulletController(bulletPrefab, bulletModel, firePos);
        else
            return new ArmourPiercingBulletController(bulletPrefab, bulletModel, firePos);
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