using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController
{
    private EnemyTankModel enemyTankModel;
    private EnemyTankView enemyTankView;

    private Rigidbody rigidBody;
    public EnemyTankController(EnemyTankModel model, EnemyTankView _tankView)
    {
        enemyTankModel = model;
        enemyTankView = GameObject.Instantiate<EnemyTankView>(_tankView, model.spawnPosition, Quaternion.identity);
        enemyTankView.SetEnemyTankController(this);
        enemyTankView.SetColorToTankParts(enemyTankModel.tankColor);

        rigidBody = enemyTankView.GetRigidbody();
    }

    public EnemyTankModel GetEnemyTankModel() { return enemyTankModel; }

    public void FixedUpdate()
    {
        Vector3 targetVector = TankView.playerLocation.position - enemyTankView.transform.position;
        Move(targetVector);
        Rotate(targetVector);
    }

    private void Move(Vector3 movementVector)
    {
        movementVector *= enemyTankModel.movementSpeed * Time.fixedDeltaTime;
        rigidBody.velocity = new Vector3(movementVector.x, rigidBody.velocity.y, movementVector.z);
    }

    private void Rotate(Vector3 rotationVector)
    {
        Quaternion lookRotation = Quaternion.LookRotation(rotationVector, Vector3.up);
        rigidBody.MoveRotation(lookRotation);
    }
}
