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
        bulletView = _bulletView;
        bulletModel = _bulletModel;

        firePos = _firePos;

        bulletView.gameObject.SetActive(true);
        bulletView.gameObject.transform.position = firePos.position;
        bulletView.gameObject.transform.rotation = firePos.rotation;

        bulletView.SetBulletController(this);
        bulletModel.SetBulletController(this);

        rigidBody = _bulletView.GetBulletRigidBody();
        fireDirection = firePos.forward;
    }

    public virtual void MoveBullet() { }

    public void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.gameObject.name + " damaged by " + bulletModel.damageDealt + " points!");
    }
}
