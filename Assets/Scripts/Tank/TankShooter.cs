using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    [SerializeField] private Transform fireTransform;

    [SerializeField] BulletScriptableObject BulletSO;

    private float minLaunchForce;
    private float maxLaunchForce;
    private float maxChargeTime;

    private BulletType bulletType;

    private float currentLaunchForce;
    private float chargeSpeed;
    private bool fired;

    private void Awake()
    {
        minLaunchForce = BulletSO.minLaunchForce;
        maxLaunchForce = BulletSO.maxLaunchForce;
        maxChargeTime = BulletSO.maxChargeTime;

        bulletType = BulletSO.bulletType;
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
        fired = false;

        BulletModel bulletModel = new BulletModel(currentLaunchForce, bulletType);
        BulletController bulletController = new BulletController(BulletPool.Instance.GetBullet(), bulletModel, fireTransform);

        currentLaunchForce = minLaunchForce;
    }
}
