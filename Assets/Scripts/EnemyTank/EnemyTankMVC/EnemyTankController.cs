using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController
{
    private EnemyTankModel enemyTankModel;
    private EnemyTankView enemyTankView;

    private Rigidbody rb;
    public EnemyTankController(EnemyTankModel model, EnemyTankView _tankView, Vector3 pos)
    {
        enemyTankModel = model;
        enemyTankModel.SetEnemyTankController(this);

        enemyTankView = GameObject.Instantiate<EnemyTankView>(_tankView, pos, Quaternion.identity);
        enemyTankView.SetEnemyTankController(this);
        enemyTankView.SetColorToTankParts(enemyTankModel.tankColor);

        rb = enemyTankView.GetRigidbody();
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
        rb.velocity = new Vector3(movementVector.x, rb.velocity.y, movementVector.z);
    }

    private void Rotate(Vector3 rotationVector)
    {
        Quaternion lookRotation = Quaternion.LookRotation(rotationVector, Vector3.up);
        rb.MoveRotation(lookRotation);
    }
}
