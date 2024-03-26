using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController : TankController<PlayerTankController>
{
    private PlayerTankView tankView;
    private PlayerTankModel tankModel;
    private Rigidbody rigidBody;

    public float currentSpeed {  get; private set; }
    public PlayerTankController(PlayerTankView _tankView, PlayerTankModel _tankModel)
    {
        tankView = GameObject.Instantiate<PlayerTankView>(_tankView);
        tankModel = _tankModel;
        rigidBody = tankView.GetRigidbody();
        tankModel.SetTankController(this);
        tankView.SetTankController(this);
        tankView.ChangeColor(tankModel.tankColor);
        currentSpeed = 0f;
    }

    public override void Move(float movement)
    {
        Vector3 moveDirection = tankView.transform.forward;

        if (movement != 0)
        {
            if (Mathf.Abs(currentSpeed) < tankModel.maxSpeed)
                currentSpeed += tankModel.acceleration * movement * Time.fixedDeltaTime;

            else if (currentSpeed >= tankModel.maxSpeed)
                currentSpeed = tankModel.maxSpeed * movement;
        }

        if (movement == 0)
        {
            if (currentSpeed > 0f)
                currentSpeed -= tankModel.acceleration * Time.fixedDeltaTime;
            else
                currentSpeed += tankModel.acceleration * Time.fixedDeltaTime;

            if (currentSpeed == 0f)
                currentSpeed = 0f;
        }

        tankView.transform.position += moveDirection * currentSpeed * Time.fixedDeltaTime;
    }

    public void OnCollisionEnter(Collision collision) => currentSpeed = 0f;

    public override void Rotate(float rotation)
    {
        Vector3 rotVector = new Vector3(0f, rotation * tankModel.rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(rotVector * Time.fixedDeltaTime);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
    }

    public PlayerTankModel GetTankModel() { return tankModel; }
}
