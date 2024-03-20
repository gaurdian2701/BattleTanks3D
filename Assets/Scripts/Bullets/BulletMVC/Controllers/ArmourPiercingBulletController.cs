using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPiercingBulletController : BulletController
{
    private const int launchForceMultiplier = 2;
    public ArmourPiercingBulletController(BulletView _bulletView) :
        base(_bulletView)
    {

    }

    public override void MoveBullet()
    {
        bulletView.GetBulletRigidBody().velocity = bulletModel.LaunchForce * launchForceMultiplier * fireDirection;
    }
}
