using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class groundCheck : MonoBehaviour
{
    private bool grounded;
    public bool isGrounded
    {
        get
        {
            return grounded;
        }
    }
    void Start()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }
    void OnTriggerStay(Collider col)
    {
        if(col.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x);
    }
}
