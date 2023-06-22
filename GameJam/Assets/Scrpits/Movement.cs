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
    private bool talk;
    private bool canTalk;
    private bool startText;
    private float dx;
    private float dy;
    private Rigidbody rb;
    private Quaternion lastDirection;
    public GameObject inputFieldHolder;

    

    public bool getText
    {
        get
        {
          return startText;
        }

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundcheck = transform.GetComponentInChildren<groundCheck>();
        startText = false;
    }

    void Update()
    {
        dx = Input.GetAxis(InputAxes.Horizontal);
        dy = Input.GetAxis(InputAxes.Vertical);
        jump = Input.GetButtonDown(InputAxes.Jump);
        talk = Input.GetButtonDown(InputAxes.Talk);

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

        if(jump && groundcheck.isGrounded)
        {
            rb.velocity = Vector3.up * jumpHeight;
        }//Check if something in the ground layer is near the Player's feet

        if(rb.velocity.y <= terminalVelocity)
        {
            rb.velocity = new Vector3(rb.velocity.x, terminalVelocity, rb.velocity.z);
        }

        if(canTalk)
        {
           if(talk)
           {
              Debug.Log("it works");
              inputFieldHolder.SetActive(true);
           }
        }
    }

     void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("NPC"))
        {
            canTalk = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("NPC"))
        {
            canTalk = false;
        }
    }
}
