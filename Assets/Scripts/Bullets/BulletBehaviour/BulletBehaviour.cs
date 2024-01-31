using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour
{
    protected RaycastHit hit;
    protected BulletView bulletView;
    protected BulletModel bulletModel;
    protected Vector3 fireDirection;
    protected Rigidbody rb;
    public virtual void ExecuteBehaviour() { }
}
