using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour //障害物生成スクリプト
{

    public GameObject[] Obstacle_prefabs; //障害物のプレハブ

    private float distance = 0; //前に障害物を生成してからの移動距離

    private Vector3 set_pos; //障害物を設置する場所

    [SerializeField] private float generate_interval = 10.0f; //何unitごとに障害物を生成するか

    [SerializeField] private GameObject Background_obj; //Backgroundクラスを持つオブジェクトを入れる

    private Background BG_sc;

    private int count = 0; //何個目の障害物を設置しているか

    // Start is called before the first frame update
    void Start()
    {
        BG_sc = Background_obj.GetComponent<Background>(); //Backgroundクラスの内容を使えるようにする
        set_pos = new Vector3 (30, -3.6f, 0); //デフォルトの障害物の設置位置

        SetObstacle(Random_Number(Obstacle_prefabs.Length), set_pos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = BG_sc.distance; //Backgroundクラスから移動距離を取得

        if(distance >= generate_interval * count) //前回障害物を生成してから一定距離を進んだとき
        {
            SetObstacle(Random_Number(Obstacle_prefabs.Length), set_pos); //障害物をランダムで選び、障害物を生成する
        }
    }

    //障害物を生成する関数
    private void SetObstacle(int n , Vector3 pos) // (どの障害物を,どこに置く)
    {

        Instantiate(Obstacle_prefabs[n], pos + (Vector3.right * Random_Interval()), Quaternion.identity); //配列Obstacle_prefabsのn番目のプレハブをposの位置に生成する
        
        count++;
    }

    //ランダムで0から指定の数までの整数を返す関数
    private int Random_Number(int size)
    {
        int n = Random.Range(0, size);
        return n;
    }

    //ランダムで生成位置をずらすための関数
    private float Random_Interval()
    {
        float n = Random.Range( -generate_interval / 2, generate_interval / 2);
        return n;
    }
}
