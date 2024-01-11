using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankView;

    private void Start()
    {
        //if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit groundHit, LayerMask.GetMask("Ground")))
        //    Instantiate(tankView, groundHit.point, Quaternion.identity);
        //else
        //    Debug.LogError("Tank Spawn failed!");
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel();
        TankController tankController = new TankController(tankView, tankModel);
    }
}
