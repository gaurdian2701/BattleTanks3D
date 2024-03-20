using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletPoolScriptableObject", menuName = "ScriptableObjects/NewBulletPool")]
public class BulletPoolScriptableObject : ScriptableObject
{
    public BulletView BulletPrefab;
    public float defaultLaunchForce;
    public float defaultDamageDealt;
    public BulletType defaultBulletType;
}
