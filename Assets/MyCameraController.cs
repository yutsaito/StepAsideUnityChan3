﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{   //UnityChanｹﾞｰﾑｵﾌﾞｼﾞｪｸﾄ
    private GameObject unitychan;
    //unitychanとカメラの距離
    private float difference;

    // Start is called before the first frame update
    void Start()
    {
        unitychan = GameObject.Find("unitychan");
        //unityちゃんとカメラの距離(z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }
}
