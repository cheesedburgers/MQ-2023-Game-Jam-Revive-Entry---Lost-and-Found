using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    private SceneManagement sceneManagement;
 
    void Start()
    {
        sceneManagement = FindObjectOfType<SceneManagement>();
    }
 
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
          sceneManagement.LoadNextScene();
        }
    }
}

