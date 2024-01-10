using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private GameObject TankPrefab;

    private void Start()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit groundHit, LayerMask.GetMask("Ground")))
            Instantiate(TankPrefab, groundHit.point, Quaternion.identity);
        else
            Debug.LogError("Tank Spawn failed!");
    }
}
