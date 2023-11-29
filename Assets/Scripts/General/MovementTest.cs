using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    public Rigidbody myRigidbody;
    private string horizontalInputAxisName = "Horizontal";
    private string verticalInputAxisName = "Vertical";
    public CharacterController player;

    Vector3 inputVector;

    public float playerSpeed;

    private void Start()
    {
        player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        inputVector.x = Input.GetAxis(horizontalInputAxisName);
        inputVector.z = Input.GetAxis(verticalInputAxisName);
        inputVector.y = 0;

        // _animator.SetBool( "_isWalking" = true);

    }

    private void FixedUpdate()
    {
        player.Move(inputVector * playerSpeed * Time.deltaTime);
    }
}
