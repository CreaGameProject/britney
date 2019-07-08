using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    float timeScore = 0;
    public GameObject ScoreObject = null;
    //public int coefficient = 10; //経過時間をスコアに変換する係数
    public float distance = 0;
    private Background BG_sc;

    // Start is called before the first frame update
    void Start()
    {
        BG_sc = GameObject.FindGameObjectWithTag("background").GetComponent<Background>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = BG_sc.distance;
        //timeScore += Time.deltaTime; //経過時間
        //float Score = timeScore * coefficient; //経過時間をスコアに変換
        Text ScoreText = gameObject.GetComponent<Text>();
        ScoreText.text = ((int)distance).ToString();

    }
}            