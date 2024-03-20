using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private TankView tankView;
    private TankModel tankModel;
    private Rigidbody rigidBody;
    public TankController(TankView _tankView, TankModel _tankModel)
    {
        tankView = GameObject.Instantiate<TankView>(_tankView);
        tankModel = _tankModel;

        rigidBody = tankView.GetRigidbody();

        tankModel.SetTankController(this);
        tankView.SetTankController(this);

        tankView.ChangeColor(tankModel.tankColor);
    }

    public void Move(float movement, float movementSpeed)
    {
        Vector3 moveDirection = movement * movementSpeed * tankView.transform.forward;
        rigidBody.velocity = new Vector3(moveDirection.x, rigidBody.velocity.y, moveDirection.z);
    }

    public void Rotate(float rotation, float rotationSpeed)
    {
        Vector3 rotVector = new Vector3(0f, rotation * rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(rotVector * Time.deltaTime);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
    }

    public TankModel GetTankModel() { return tankModel; }
}
