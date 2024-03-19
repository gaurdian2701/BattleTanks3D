
using UnityEngine;

public class BulletCreationController
{
    private BulletType bulletType;
    private BulletModel bulletModel;
    private Transform fireTransform;

    public BulletCreationController(BulletModel bulletModel, BulletType bulletType, Transform fireTransform)
    {
        this.bulletType = bulletType;
        this.bulletModel = bulletModel;
        this.fireTransform = fireTransform;
    }

    public BulletCreationController(BulletType bulletType, Transform fireTransform)
    {
        this.bulletType = bulletType;
        this.fireTransform = fireTransform;
    }
    public BulletController CreateBulletController()
    {
        BulletController bulletController = CreateBulletControllerAccordingToType(bulletType);
        return bulletController;
    }

    public BulletController CreateBulletController(BulletModel bulletModel)
    {
        this.bulletModel = bulletModel;
        BulletController bulletController = CreateBulletControllerAccordingToType(bulletType);
        return bulletController;    
    }

    private BulletController CreateBulletControllerAccordingToType(BulletType bulletType)
    {
        BulletController bulletController;
        switch (bulletType)
        {
            case BulletType.HighExplosive:
                bulletController = new HighExplosiveBulletController(BulletPool.Instance.GetBullet(), bulletModel, fireTransform);
                break;

            case BulletType.ArmourPiercing:
                bulletController = new ArmourPiercingBulletController(BulletPool.Instance.GetBullet(), bulletModel, fireTransform);
                break;

            case BulletType.Homing:
                bulletController = new HomingBulletController(BulletPool.Instance.GetBullet(), bulletModel, fireTransform);
                break;

            default:
                bulletController = new ArmourPiercingBulletController(BulletPool.Instance.GetBullet(), bulletModel, fireTransform);
                break;
        }
        return bulletController;
    }
}
