using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPiercingBulletController : BulletController
{
    private const int launchForceMultiplier = 2;
    public ArmourPiercingBulletController(BulletView _bulletView, 
        BulletModel _bulletModel, 
        Transform firePos) :
        base(_bulletView,
            _bulletModel,
            firePos)
    {
    }

    public override void MoveBullet()
    {
        rigidBody.velocity = fireDirection * bulletModel.launchForce * launchForceMultiplier;
    }
}
