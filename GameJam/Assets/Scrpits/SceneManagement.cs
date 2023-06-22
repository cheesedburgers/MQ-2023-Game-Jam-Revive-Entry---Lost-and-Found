using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement  : MonoBehaviour
{

   [SerializeField] private Movement player;
    [SerializeField] private int nextBuildSceneIndex;
 
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>();
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextBuildSceneIndex);
    }

}
