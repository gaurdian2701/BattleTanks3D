using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankView : MonoBehaviour
{
    [SerializeField] private AudioSource tankMovementAudioSource;
    [SerializeField] private Rigidbody rigidBody;

    private PlayerTankController tankController;
    private float movement;
    private float rotation;
    private const float minPitch = 1f;
    private const float maxPitch = 1.75f;

    public MeshRenderer[] tankChildren;
    public static Transform playerLocation;

    private void Awake()
    {
        playerLocation = transform;
    }

    private void Start()
    {
        CinemachineVirtualCamera cam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        cam.Follow = this.transform;
        cam.LookAt = this.transform;
    }

    private void Update()
    {
        MovementInput();
        AudioUpdate();
    }

    private void FixedUpdate()
    {
        tankController.Move(movement);
        tankController.Rotate(rotation);
    }
    public void SetTankController(PlayerTankController _tankController)
    {
        tankController = _tankController; 
    }

    public Rigidbody GetRigidbody() { return rigidBody; }

    public void ChangeColor(Material tankColor)
    {
        for(int i = 0; i < tankChildren.Length; i++)
            tankChildren[i].material = tankColor;
    }
    private void MovementInput()
    {
        movement = Input.GetAxisRaw("Vertical");
        rotation = Input.GetAxisRaw("Horizontal");
    }

    private void OnCollisionEnter(Collision collision) => tankController.OnCollisionEnter(collision);

    private void AudioUpdate()
    {
        float normalizedVelocity = Mathf.Abs(tankController.currentSpeed) / tankController.GetTankModel().maxSpeed;
        float currentPitch = Mathf.Lerp(minPitch, maxPitch, normalizedVelocity);
        tankMovementAudioSource.pitch = currentPitch;
    }
}
