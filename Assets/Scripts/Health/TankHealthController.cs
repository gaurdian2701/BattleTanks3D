using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TankHealthController<T> : IDamageable where T : TankController<T>
{
    private float currentHealth;
    private TankController<T> controller;
    public TankHealthController(TankController<T> controller)
    {
        this.controller = controller;
        Debug.Log(typeof(T));
    }
    public void TakeDamage(float damage)
    {

    }
    public void OnDied()
    {
    }
}
