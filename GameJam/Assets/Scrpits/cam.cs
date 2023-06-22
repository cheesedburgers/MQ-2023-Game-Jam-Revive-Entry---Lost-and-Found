using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
     [SerializeField] private Transform player;
   [SerializeField] private float moveDelay = 0.4f;
 void FixedUpdate()
 {
    Vector3 offset = Vector3.Lerp(transform.position, player.position, moveDelay);
    transform.position = offset;  
 }
}
