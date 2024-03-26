using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelarationScript : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelaration;
    [SerializeField] private float decelaration;

    private float currentSpeed;
    private void Awake()
    {
        currentSpeed = 0f;
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition = new Vector3(0f, 0f, currentSpeed);
        transform.position += currentPosition * Time.deltaTime;
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        if (Input.GetKey(KeyCode.Space))
            IncreaseSpeed();
        else
            DecreaseSpeed();
    }
    private void IncreaseSpeed()
    {
        if(currentSpeed <= maxSpeed)
            currentSpeed += accelaration * Time.deltaTime;
    }

    private void DecreaseSpeed()
    {
        if (currentSpeed > 0)
            currentSpeed -= decelaration * Time.deltaTime;
    }
}
