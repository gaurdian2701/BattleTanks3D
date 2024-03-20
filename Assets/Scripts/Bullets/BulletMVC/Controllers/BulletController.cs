using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    protected BulletView bulletView;
    protected BulletModel bulletModel;
    protected Transform firePos;
    protected Vector3 fireDirection;

    public BulletController(BulletView _bulletView)
    {
        bulletView = GameObject.Instantiate(_bulletView);
        bulletView.SetBulletController(this);
    }

    public void ConfigureBullet(BulletData bulletData)
    {
        if (bulletView == null)
            return;

        bulletView.gameObject.SetActive(true);
        this.bulletModel = bulletData.BulletModel;
        SetFiringDirection(bulletData.FirePos);
    }

    private void SetFiringDirection(Transform firingPosition)
    {
        firePos = firingPosition;
        fireDirection = firingPosition.forward;
        bulletView.transform.SetPositionAndRotation(firingPosition.position, firingPosition.rotation);
    }
    public virtual void MoveBullet() { }
    public void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Damaged " + other.gameObject);
    }
}
