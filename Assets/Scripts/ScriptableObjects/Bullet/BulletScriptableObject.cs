using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBullet")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletType bulletType;
    public float minLaunchForce;
    public float maxLaunchForce;
    public float maxChargeTime;
}
