using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        bulletController.BulletMove();
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    public Rigidbody GetBulletRigidBody() { return rb; }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false);
    }

}
