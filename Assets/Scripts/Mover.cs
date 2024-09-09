using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Mover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public LayerMask GroundLayer;
    public float jumpHeight = 2f;

    protected Vector3 moveDirection = Vector3.zero;
    protected float horizontalInput, verticalInput;
    protected bool grounded = true;

    protected CharacterController controller;
    protected Vector3 fallingVelocity;

    protected void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    protected void GetMoveInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
    }

    protected void MoveObj(Vector3 moveDirection)
    {
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    protected void ApplyGravity()
    {
        if (grounded && fallingVelocity.y < 0)
        {
            fallingVelocity.y = 0f;
        }

        fallingVelocity.y += gravity * Time.deltaTime;

        controller.Move(fallingVelocity * Time.deltaTime);
    }

    protected void GroundCheck()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, controller.height * 0.5f + 0.005f, GroundLayer);
        //grounded = controller.isGrounded;
    }

    protected void Jump()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            fallingVelocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
