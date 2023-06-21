using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour
{
    [SerializeField] private float trampolineJumpHeight = 10;
    [SerializeField] private float trampolineSensitivity;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.relativeVelocity.y);
        if(collision.collider.CompareTag("Player") && collision.relativeVelocity.y < -trampolineSensitivity)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * trampolineJumpHeight, ForceMode.Impulse);
        }
    }
}
