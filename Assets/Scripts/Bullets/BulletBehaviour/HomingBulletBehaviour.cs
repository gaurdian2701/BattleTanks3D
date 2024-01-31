using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class HomingBulletBehaviour : BulletBehaviour
{
    private bool enemyFound;
    private LayerMask enemyMask;
    public HomingBulletBehaviour(BulletView _bulletView, BulletModel _bulletModel, Vector3 _fireDirection)
    {
        enemyFound = false;
        bulletView = _bulletView;
        bulletModel = _bulletModel;
        enemyMask = bulletView.GetEnemyMask();
        fireDirection = _fireDirection;
        rb = bulletView.GetBulletRigidBody();
    }

    public override void ExecuteBehaviour()
    {
        if (!enemyFound)
        {
            if (Physics.SphereCast(bulletView.transform.position, 10f, bulletView.transform.forward, out hit, 5f, enemyMask)) //use sphere cast to check if enemy is near
                enemyFound = true;

            else
                rb.velocity = bulletModel.launchForce * fireDirection;
        }
        else
            HomeToTarget(hit.transform);       //Homing Logic
    }

    private void HomeToTarget(Transform targetTransform)
    {
        Quaternion lookRotation = Quaternion.LookRotation(targetTransform.transform.position - bulletView.transform.position, Vector3.up);
        rb.MoveRotation(lookRotation);

        rb.velocity = bulletView.transform.forward * bulletModel.launchForce;
    }
}
