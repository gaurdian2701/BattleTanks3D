using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public float LaunchForce;
    public float DamageDealt;
    public BulletType BulletType;
    public BulletModel(float _launchForce, BulletType _bulletType, float _damageDealt)
    {
        LaunchForce = _launchForce;
        DamageDealt = _damageDealt;
        BulletType = _bulletType;    
    }
}
