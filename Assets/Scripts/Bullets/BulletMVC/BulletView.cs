using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private BoxCollider hitBox;
    private BulletController bulletController;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hitBox.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        bulletController.BulletMove();
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    public Rigidbody GetBulletRigidBody() { return rb; }

    public BoxCollider GetBoxCollider() { return hitBox; }

    public LayerMask GetEnemyMask() { return enemyMask;}

    private void OnTriggerEnter(Collider other)
    {
        bulletController.OnTriggerEnter(other);
    }
    private void OnCollisionEnter(Collision collision)
    {
        hitBox.gameObject.SetActive(true);
        StartCoroutine(nameof(WaitForImpact));
    }

    private IEnumerator WaitForImpact()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        this.gameObject.SetActive(false);
    }
}
