using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class HomingBulletController : BulletController
{
    private bool enemyHasBeenFound;
    private LayerMask enemyMask;
    private RaycastHit hit;
    private const float sphereCastRadius = 10f;
    private const float sphereCastDistance = 5f;
    public HomingBulletController (BulletView _bulletView) : base(_bulletView)
    {
        enemyHasBeenFound = false;
        enemyMask = bulletView.GetEnemyMask();
    }

    public override void MoveBullet()
    {
        if (!enemyHasBeenFound)
        {
            if (Physics.SphereCast(bulletView.transform.position, sphereCastRadius, bulletView.transform.forward, out hit, sphereCastDistance, enemyMask)) //use sphere cast to check if enemy is near
                enemyHasBeenFound = true;

            else
                bulletView.GetBulletRigidBody().velocity = bulletModel.LaunchForce * fireDirection;
        }
        else
            HomeToTarget(hit.transform);       //Homing Logic
    }

    private void HomeToTarget(Transform targetTransform)
    {
        Quaternion lookRotation = Quaternion.LookRotation(targetTransform.transform.position - bulletView.transform.position, Vector3.up);
        bulletView.GetBulletRigidBody().MoveRotation(lookRotation);

        bulletView.GetBulletRigidBody().velocity = bulletView.transform.forward * bulletModel.LaunchForce;
    }
}
