using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankView : MonoBehaviour 
{
    public MeshRenderer[] tankParts;

    private EnemyTankController controller;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void SetEnemyTankController(EnemyTankController _controller)
    {
        controller = _controller;
    }

    public void SetColorToTankParts(Material tankColor)
    {
        foreach (MeshRenderer part in tankParts)
            part.material = tankColor;
    }
    public Rigidbody GetRigidbody() { return rb; }

    private void FixedUpdate()
    {
        controller.FixedUpdate();
    }
}
