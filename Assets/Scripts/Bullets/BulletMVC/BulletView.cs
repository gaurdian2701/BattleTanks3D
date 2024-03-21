using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private BoxCollider hitBox;
    [SerializeField] private Rigidbody rigidBody;

    private BulletController bulletController;

    private void Awake()
    {
        hitBox.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        bulletController.MoveBullet();
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    public Rigidbody GetBulletRigidBody() { return rigidBody; }

    public BoxCollider GetBoxCollider() { return hitBox; }

    public LayerMask GetEnemyMask() { return enemyMask;}
    public void SetHitBoxSize(Vector3 size) => hitBox.size = size;

    private void OnTriggerEnter(Collider other)
    {
        bulletController.OnTriggerEnter(other);
        GameService.Instance.EventService.OnBattleEventOccurred(BattleEventType.ShellExplosion);
    }
    private void OnCollisionEnter(Collision collision)
    {
        hitBox.gameObject.SetActive(true);
        StartCoroutine(WaitForImpact());
    }

    private IEnumerator WaitForImpact()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        this.gameObject.SetActive(false);
        GameService.Instance.PoolService.BulletPool.ReturnItemToPool(bulletController);
    }
}
