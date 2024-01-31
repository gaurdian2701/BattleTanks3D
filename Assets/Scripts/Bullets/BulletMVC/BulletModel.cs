using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public float launchForce;
    public BulletType bulletType;
    public float damageDealt;

    private BulletController bulletController;

    public BulletModel(float _launchForce, BulletType _bulletType, float _damageDealt)
    {
        launchForce = _launchForce;
        bulletType = _bulletType;
        damageDealt = _damageDealt;
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
}
