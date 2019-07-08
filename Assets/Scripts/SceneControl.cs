using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 100;
        var type = Type.GetType("Border.cs");

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Scene nowScene = SceneManager.GetActiveScene();
            if (nowScene.name == "StartScene")
            {
                SceneManager.LoadScene("GameScene");
            }
            if (nowScene.name == "GameScene")
            {
                SceneManager.LoadScene("ResultScene");
            }
            if (nowScene.name == "ResultScene")
            {
                SceneManager.LoadScene("StartScene");
            }
                
        }
            
       
    }
   
}

