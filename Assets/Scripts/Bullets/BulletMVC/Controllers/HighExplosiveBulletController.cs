using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class HighExplosiveBulletController : BulletController
{
    private readonly Vector3 hitBoxSize = new Vector3(5f, 1f, 5f);

    public HighExplosiveBulletController(BulletView _bulletView,
        BulletModel _bulletModel,
        Transform firePos) :
       base(_bulletView, _bulletModel, firePos)

    {
        bulletView.SetHitBoxSize(hitBoxSize);
    }

    public override void MoveBullet()
    {
        rigidBody.velocity = fireDirection * bulletModel.LaunchForce;
    }
}
