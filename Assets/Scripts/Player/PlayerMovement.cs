using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody _rb;
    
    Transform _cam;

    private Camera _mainCamera;

    public Animator animator;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = FindObjectOfType<Camera>();

        _cam = Camera.main.transform;


    }

    private void Update()
    {

        Ray cameraRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;



        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        MeleeAttackInput();
        DodgeRoll();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        Vector3 forwardRelativeVerticalInput = vertical * forward * (moveSpeed + 1f);
        Vector3 rightRelativeHorizontalInput = horizontal * right * (moveSpeed - 1f);

        Vector3 cameraRelativeMovement = (forwardRelativeVerticalInput + rightRelativeHorizontalInput) * Time.deltaTime;

        this.transform.Translate(cameraRelativeMovement, Space.World);


        animator.SetFloat("Forward", vertical);
        animator.SetFloat("Turn", horizontal);

    }

    

    public void MeleeAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Melee");
            
        }
    }

    public void DodgeRoll()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("Roll");
        }
    }

}
