using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPiercingBulletBehaviour : BulletBehaviour
{
    public ArmourPiercingBulletBehaviour(BulletView _bulletView, BulletModel _bulletModel, Vector3 _fireDirection)
    {
        bulletView = _bulletView;
        bulletModel = _bulletModel;
        fireDirection = _fireDirection;
        rb = bulletView.GetBulletRigidBody();
    }

    public override void ExecuteBehaviour()
    {
        rb.velocity = fireDirection * bulletModel.launchForce * 2;
    }
}
