using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public float launchForce;
    public float damageDealt;
    public BulletModel(float _launchForce, float _damageDealt)
    {
        launchForce = _launchForce;
        damageDealt = _damageDealt;
    }
}
