using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private TankView tankView;
    private TankModel tankModel;

    private Rigidbody rb;
    public TankController(TankView _tankView, TankModel _tankModel)
    {
        tankView = GameObject.Instantiate<TankView>(_tankView);
        tankModel = _tankModel;

        rb = tankView.GetRigidbody();

        tankModel.SetTankController(this);
        tankView.SetTankController(this);

        tankView.ChangeColor(tankModel.tankColor);
    }

    public void Move(float movement, float movementSpeed)
    {
        Vector3 moveDirection = tankView.transform.forward * movement * movementSpeed;

        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
    }

    public void Rotate(float rotation, float rotationSpeed)
    {
        Vector3 rotVector = new Vector3(0f, rotation * rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(rotVector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public TankModel GetTankModel() { return tankModel; }
}
