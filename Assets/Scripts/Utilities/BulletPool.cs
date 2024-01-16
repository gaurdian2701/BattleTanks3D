using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : GenericMonoSingleton<BulletPool>
{
    [SerializeField] private int poolSize;
    [SerializeField] private BulletView bulletPrefab;

    [SerializeField] private List<BulletView> bulletList = new List<BulletView>();

    private void Start()
    {
        bulletList.Capacity = poolSize;

        for(int i=0; i<bulletList.Capacity; i++)
        {
            BulletView bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            bulletList.Add(bullet);
        }
    }

    public BulletView GetBullet()
    {
        for(int i=0; i<bulletList.Capacity; i++)
        {
            if (!bulletList[i].gameObject.activeInHierarchy)
                return bulletList[i];
        }

        return null;
    }   
}
