﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private Rigidbody rb;

    private float movement;
    private float rotation;

    public MeshRenderer tankColor;
    public MeshRenderer[] tankChildren;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.localPosition = new Vector3(0f, 3f, -8f);
    }

    private void Update()
    {
        MovementInput();
    }
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController; 
    }

    public Rigidbody GetRigidbody() { return rb; }

    public void ChangeColor(Material tankColor)
    {
        for(int i = 0; i < tankChildren.Length; i++)
            tankChildren[i].material = tankColor;
    }
    private void MovementInput()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");

        if(movement != 0)
            tankController.Move(movement, tankController.GetTankModel().movementSpeed);

        if(rotation != 0)
            tankController.Rotate(rotation, tankController.GetTankModel().rotationSpeed);
    }
}
