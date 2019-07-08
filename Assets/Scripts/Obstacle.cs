using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Background BG_sc;

    // Start is called before the first frame update
    void Start()
    {
        //タグから背景オブジェクトをを探し、背景オブジェクトのBackgaroundクラスを取得
        BG_sc = GameObject.FindGameObjectWithTag("background").GetComponent<Background>();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(BG_sc.scrool_speed, 0, 0); //背景と同じスピードで動かす

        if (transform.position.x <= -15.0f) //障害物が画面外に出たとき
        {
            Destroy(gameObject); //オブジェクトを消滅させる
        }
    }
}
