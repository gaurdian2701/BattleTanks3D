using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    protected BulletView bulletView;
    protected BulletModel bulletModel;
    protected Transform firePos;

    protected Rigidbody rigidBody;
    protected Vector3 fireDirection;

    public BulletController(BulletView _bulletView, BulletModel _bulletModel, Transform _firePos)
    {
        firePos = _firePos;
        bulletView = GameObject.Instantiate(_bulletView, firePos.position, firePos.rotation);
        bulletView.SetBulletController(this);
        bulletModel = _bulletModel;

        rigidBody = _bulletView.GetBulletRigidBody();
        fireDirection = firePos.forward;
    }

    public virtual void MoveBullet() {}
    public void OnTriggerEnter(Collider other) 
    {
        GameService.Instance.PoolService.BulletPool.ReturnItemToPool(this);
    }
}
