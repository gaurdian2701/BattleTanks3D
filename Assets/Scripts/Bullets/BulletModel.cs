using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public float launchForce;
    public BulletType bulletType;

    private BulletController bulletController;

    public BulletModel(float _launchForce, BulletType _bulletType)
    {
        launchForce = _launchForce;
        bulletType = _bulletType;
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
}
