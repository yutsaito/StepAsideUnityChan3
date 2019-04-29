using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    //Itemプレハブにアタッチしてつかう。
    //unithchanの取得のための変数
    GameObject unitychan;
    // Start is called before the first frame update
    void Start()
    {
        unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.z < unitychan.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
}
