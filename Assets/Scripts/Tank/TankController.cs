using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController<T> where T : TankController<T>
{
    protected TankHealthController<T> tankHealthController;
    public TankController()
    {
        tankHealthController = new TankHealthController<T>(this);
    }

    public void TakeDamage(float damage) => tankHealthController.TakeDamage(damage);
    public virtual void Move(float movement, float movementSpeed) { }
    public virtual void Rotate(float rotation, float rotationSpeed) { }
    public virtual void Move(Vector3 movementVector) { }
    public virtual void Rotate(Vector3 rotationVector) { }
}
