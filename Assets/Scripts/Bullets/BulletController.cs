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
    }

    public void BulletMove()
    {
        rb.velocity = bulletModel.launchForce * fireDirection;
    }
    public BulletModel GetBulletModel() { return bulletModel; }
}
