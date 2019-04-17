using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{   //ｱﾆﾒｰｼｮﾝするためのｺﾝﾎﾟｰﾈﾝﾄを入れる
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //Animatorｺﾝﾎﾟｰﾈﾝﾄを取得
        this.myAnimator = GetComponent<Animator>();

        //走るｱﾆﾒｰｼｮﾝを開始
        this.myAnimator.SetFloat("Speed", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
