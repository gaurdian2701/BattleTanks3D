using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoolServiceScriptableObject", menuName = "ScriptableObjects/NewPoolService")]
public class PoolServiceScriptableObject : ScriptableObject
{
    public BulletPoolScriptableObject BulletPoolSO;
}
