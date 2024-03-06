using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPiercingBulletController : BulletController
{
    public ArmourPiercingBulletController(BulletView _bulletView, 
        BulletModel _bulletModel, 
        Transform firePos) :
        base(_bulletView,
            _bulletModel,
            firePos)
    {
    }

    public override void UpdateBullet()
    {
        rb.velocity = fireDirection * bulletModel.launchForce * 2;
    }
}
