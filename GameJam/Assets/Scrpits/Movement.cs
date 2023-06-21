using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpHeight = 5;
    [SerializeField] private float terminalVelocity = -1;
    private groundCheck groundcheck;
    private bool jump;
    private float dx;
    private float dy;
    private Rigidbody rb;
    private Quaternion lastDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       groundcheck = transform.GetComponentInChildren<groundCheck>();
    }

    void Update()
    {
        dx = Input.GetAxis(InputAxes.Horizontal);
        dy = Input.GetAxis(InputAxes.Vertical);
        jump = Input.GetButtonDown(InputAxes.Jump);

        rb.velocity = new Vector3(dx*speed,rb.velocity.y, dy*speed);

        if(dx != 0 || dy != 0)
        {
            Vector3 rotationDirection = Quaternion.Euler(0,0,0) * new Vector3(dx, 0, dy);
            transform.rotation = Quaternion.LookRotation(rotationDirection, Vector3.up);
            lastDirection = transform.rotation; 
        }
        else
        {
            transform.rotation = lastDirection;     //stop player from continously rotating when there is no input
        }
// this should work
        if(jump && groundcheck.isGrounded)
        {
            rb.velocity = Vector3.up * jumpHeight;
        }//Check if something in the ground layer is near the Player's feet

        if(rb.velocity.y <= terminalVelocity)
        {
            rb.velocity = new Vector3(rb.velocity.x, terminalVelocity, rb.velocity.z);
        }
    }
}
