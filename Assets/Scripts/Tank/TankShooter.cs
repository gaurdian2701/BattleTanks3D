using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    [SerializeField] private Transform fireTransform;
    [SerializeField] private BulletScriptableObject BulletSO;

    private float minLaunchForce;
    private float maxLaunchForce;
    private float maxChargeTime;
    private BulletType bulletType;
    private float currentLaunchForce;
    private float chargeSpeed;
    private bool fired;
    private float bulletDamage;
    private BulletCreationController bulletCreationController;

    private void Awake()
    {
        minLaunchForce = BulletSO.minLaunchForce;
        maxLaunchForce = BulletSO.maxLaunchForce;
        maxChargeTime = BulletSO.maxChargeTime;
        bulletType = BulletSO.bulletType;
        bulletDamage = BulletSO.damageDealt;

        bulletCreationController = new BulletCreationController(bulletType, fireTransform);
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
        GameService.Instance.EventService.BulletFired?.Invoke();
        fired = false;
        currentLaunchForce = minLaunchForce;
        BulletModel bulletModel = new BulletModel(currentLaunchForce, bulletDamage);
        BulletController bulletController = bulletCreationController.CreateBulletController(bulletModel);

        //switch(bulletType)
        //{
        //    case BulletType.HighExplosive:
        //        bulletController = new HighExplosiveBulletController(BulletPool.Instance.GetBullet(), bulletModel, fireTransform);
        //        break;

        //    case BulletType.ArmourPiercing:
        //        bulletController = new ArmourPiercingBulletController(BulletPool.Instance.GetBullet(), bulletModel, fireTransform);
        //        break;

        //    case BulletType.Homing:
        //        bulletController = new HomingBulletController(BulletPool.Instance.GetBullet(), bulletModel, fireTransform);
        //        break;

        //    default:
        //        bulletController = new ArmourPiercingBulletController(BulletPool.Instance.GetBullet(), bulletModel, fireTransform);
        //        break;
        //}
    }
}
