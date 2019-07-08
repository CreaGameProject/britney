using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour //背景スクロールスクリプト
{
    public float scrool_speed = -0.05f;　//画面スクロールのスピード
    public float offset = 24.8f; //画像に継ぎ目が見えない位置を入力
    public float distance = 0.0f; //移動距離
    public bool is_gameover = false; //ゲームオーバーかどうか(プレイヤーのスクリプトから取得)

    [SerializeField] private float add_speed = 0.0001f; //1秒ごこに足される速度
    [SerializeField] private GameObject other_background; //もう一方の背景画像オブジェクト

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!is_gameover) //ゲームオーバー時にスクロールを止める
        {
            //画像が画面外に出たら画面の先頭に移動する
            if (transform.position.x <= -offset)
            {
                transform.position = new Vector3(other_background.transform.position.x + offset, 0, 0);
            }

            transform.Translate(scrool_speed, 0, 0); //画像を移動させる

            distance -= scrool_speed; //移動距離を加算
            scrool_speed -= add_speed * Time.deltaTime; //速度を変更
        }
    }
}
