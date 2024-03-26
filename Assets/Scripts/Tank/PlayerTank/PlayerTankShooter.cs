﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankShooter : MonoBehaviour
{
    [SerializeField] private Transform fireTransform;
    [SerializeField] private BulletScriptableObject BulletSO;
    [SerializeField] private AudioSource tankShotAudioSource;

    private float minLaunchForce;
    private float maxLaunchForce;
    private float maxChargeTime;
    private float currentLaunchForce;
    private float chargeSpeed;
    private bool fired;
    private float bulletDamage;

    private void Awake()
    {
        minLaunchForce = BulletSO.minLaunchForce;
        maxLaunchForce = BulletSO.maxLaunchForce;
        maxChargeTime = BulletSO.maxChargeTime;
        bulletDamage = BulletSO.damageDealt;
    }
    private void OnEnable()
    {
        currentLaunchForce = minLaunchForce;
    }

    private void Start()
    {
        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
    }

    private void Update()
    {
        if (currentLaunchForce >= maxLaunchForce && !fired)
        {
            currentLaunchForce = maxLaunchForce;
            Fire();
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            fired = false;
            currentLaunchForce = minLaunchForce;
        }

        else if (Input.GetKey(KeyCode.Space) && !fired)
        {
            currentLaunchForce += chargeSpeed * Time.deltaTime;
        }

        else if (Input.GetKeyUp(KeyCode.Space) && !fired)
        {
            Fire();
        }
    }
    private void Fire()
    {
        tankShotAudioSource.PlayOneShot(tankShotAudioSource.clip);
        GameService.Instance.EventService.InvokeBattleEventOccurredEvent(BattleEventType.TankShellFired);
        fired = false;
        currentLaunchForce = minLaunchForce;
        BulletModel bulletModel = new BulletModel(currentLaunchForce, BulletSO.bulletType, bulletDamage);
        BulletData bulletData = new BulletData(bulletModel, fireTransform);
        BulletController bulletController;

        switch(BulletSO.bulletType)
        {
            case BulletType.HighExplosive:
                bulletController = GameService.Instance.PoolService.BulletPool.GetBullet<HighExplosiveBulletController>();
                break;

            case BulletType.Homing:
                bulletController = GameService.Instance.PoolService.BulletPool.GetBullet<HomingBulletController>();
                break;

            case BulletType.ArmourPiercing:
                bulletController = GameService.Instance.PoolService.BulletPool.GetBullet<ArmourPiercingBulletController>();
                break;

            default:
                bulletController = GameService.Instance.PoolService.BulletPool.GetBullet<ArmourPiercingBulletController>();
                break;
        }
        bulletController.ConfigureBullet(bulletData);
    }
}
