using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabをいれる
    public GameObject coinPrefab;
    //cornPfrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    public int startPos = -160;
    //ゴール地点
    public int goalPos = 120;
    //アイテムを出すX方向の範囲
    public float posRange = 3.4f;

    GameObject unitychan;

    //CarTagn等を持つGameObject(ｲﾝｽﾀﾝｽ)を取得するための配列変数
    GameObject[] cars;
    GameObject[] coins;
    GameObject[] trafficCones;


    // Start is called before the first frame update
    void Start()
    {
        //一定の距離(15m)ごとにアイテムを生成
         for (int i = startPos; i < goalPos; i += 15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            //0,1,2はｺｰﾝ
            if (num <= 2)
            {
                //ｺｰﾝをx軸方向に一直線に生成
                for(float j = -1; j <= 1; j += 0.4f)
                {
                    //Instantiate でｺｰﾝ作製
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //ﾚｰﾝごとにアイテムを生成
                for(int j = -1; j <= 1; j++)
                {
                    //ｱｲﾃﾑの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60% ｺｲﾝ配置：30％車配置：10％何もなし  
                    if(1<=item && item <= 6)
                    {
                        //ｺｲﾝ生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);    
                    }else if(7<=item && item <= 9)
                    {
                        //車生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }

        }

        //unitychanをGameObjectとして取得
        unitychan = GameObject.Find("unitychan");
        //ｲﾝｽﾀﾝｽを種類ごとに配列に入れる
        cars = GameObject.FindGameObjectsWithTag("CarTag");
//        coins = GameObject.FindGameObjectsWithTag("CoinTag");
 //       trafficCones = GameObject.FindGameObjectsWithTag("TrafficConeTag");

        Debug.Log(cars.Length);

                       
    }

    // Update is called once per frame
    void Update()
    {
        /*
        foreach(GameObject item in cars)
        {
            if (item.transform.position.z < unitychan.transform.position.z) {
                Destroy(item);
            }
        }
        */
        
      /*  
        for (int i = 0; i<=cars.Length; i++)
        {
            if (cars[i].transform.position.z < unitychan.transform.position.z)
            {
                Destroy(cars[i]);
                cars.RemoveAt(i);
            }
        }
       */ 
        /*
        for (int i = 0; i <= coins.Length; i++)
        {
            if (coins[i].transform.position.z < unitychan.transform.position.z)
            {
                Destroy(coins[i]);
            }
        }
        for (int i = 0; i <= trafficCones.Length; i++)
        {
            if (trafficCones[i].transform.position.z < unitychan.transform.position.z)
            {
                Destroy(trafficCones[i]);
            }
        }
        */
    }
/*
    // カメラに写っていないときに呼ばれる関数
    void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);
    }
*/
}
