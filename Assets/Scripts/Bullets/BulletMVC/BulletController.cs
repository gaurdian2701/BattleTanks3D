using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    private BulletView bulletView;
    private BulletModel bulletModel;
    private Transform firePos;

    private Rigidbody rb;
    private Vector3 fireDirection;

    private BulletBehaviour bulletBehaviour;

    public BulletController(BulletView _bulletView, BulletModel _bulletModel, Transform _firePos)
    {
        bulletView = _bulletView;
        bulletModel = _bulletModel;

        firePos = _firePos;

        bulletView.gameObject.SetActive(true);
        bulletView.gameObject.transform.position = firePos.position;
        bulletView.gameObject.transform.rotation = firePos.rotation;

        bulletView.SetBulletController(this);
        bulletModel.SetBulletController(this);

        rb = _bulletView.GetBulletRigidBody();
        fireDirection = firePos.forward;

        DecideBehaviour(bulletModel.bulletType);
    }

    private void DecideBehaviour(BulletType bullet)
    {
        switch(bullet)
        {
            case BulletType.ArmourPiercing:
                bulletBehaviour = new ArmourPiercingBulletBehaviour(bulletView, bulletModel, fireDirection);
                break;

            case BulletType.Homing:
                bulletBehaviour = new HomingBulletBehaviour(bulletView, bulletModel, fireDirection);
                break;

            case BulletType.HighExplosive:
                bulletBehaviour =  new HighExplosiveBulletBehaviour(bulletView, bulletModel, fireDirection, bulletView.GetBoxCollider());
                break;

            default: 
                bulletBehaviour = new ArmourPiercingBulletBehaviour(bulletView, bulletModel, fireDirection);
                break;
        }
    }
    public void BulletMove()
    {
        bulletBehaviour.ExecuteBehaviour();
    }
    public BulletModel GetBulletModel() { return bulletModel; }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(bulletModel.damageDealt + " damage dealt to " + other.gameObject.name);
    }
}
