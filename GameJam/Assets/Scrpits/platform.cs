using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private Transform highPoint;
    private Transform lowPoint;
    private Transform platforms;
    [SerializeField] private float platformSpeed = 5.0f;
    [SerializeField] private bool startAtHighPoint = false;
    private float direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        Transform point1 = transform.GetChild(0).transform;
        Transform point2 = transform.GetChild(1).transform;

        if(point1.position.y > point2.position.y)
        {
            highPoint = point1;
            lowPoint = point2;
        }
        else
        {
            highPoint = point2;
            lowPoint = point1;
        }

        platforms = transform.GetChild(2).transform;

        if(startAtHighPoint)
        {
            platforms.position = highPoint.position;
        }
        else
        {
            platforms.position = lowPoint.position;
        }

        if(point1.position.y > point2.position.y)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        platforms.Translate(Vector3.up * direction * platformSpeed * Time.deltaTime);

        if((platforms.position.y > highPoint.position.y) || (platforms.position.y < lowPoint.position.y))
        {
            direction *= -1;
        }
    }
}