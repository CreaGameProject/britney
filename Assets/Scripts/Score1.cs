using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score1 : MonoBehaviour
{
     public int score;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Text>().text = ""+GameObject.Find("GameObject").GetComponent<SceneControl>().score.ToString();
    }
   
    // Update is called once per frame
    void Update()
    {
      
    }
}
