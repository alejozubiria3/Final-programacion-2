using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public float rotationSpeed;
    public Vector2 turn;
    public Rigidbody myRigidBody;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;                       //hace invisible el cursor
    }

    private void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * rotationSpeed;                     
        transform.localRotation = Quaternion.Euler(turn.y, turn.x, 0);
    }
}
