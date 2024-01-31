using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class HighExplosiveBulletBehaviour : BulletBehaviour
{
    public HighExplosiveBulletBehaviour(BulletView _bulletView, BulletModel _bulletModel, Vector3 _fireDirection, BoxCollider hitBox)
    {
        bulletView = _bulletView;
        bulletModel = _bulletModel;
        fireDirection = _fireDirection;
        rb = bulletView.GetBulletRigidBody();

        hitBox.size = new Vector3(5f, hitBox.size.y, 5f);
    }

    public override void ExecuteBehaviour()
    {
        rb.velocity = fireDirection * bulletModel.launchForce;
    }
}
