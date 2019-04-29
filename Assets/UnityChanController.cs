using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{   //ｱﾆﾒｰｼｮﾝするためのｺﾝﾎﾟｰﾈﾝﾄを入れる
    private Animator myAnimator;
    //Unityちゃんを移動させるｺﾝﾎﾟｰﾈﾝﾄを入れる
    private Rigidbody myRigidbody;
    //前進するための力
    private float forwardForce = 800.0f;
    //左右に移動させる力
    private float turnForce = 500.0f;
    //ｼﾞｬﾝﾌﾟするための力
    private float upForce = 500.0f;
    //左右の移動できる範囲
    private float movableRange = 3.4f;
    //動きを減衰させる係数
    private float coefficient = 0.95f;
    //ｹﾞｰﾑ終了の判定
    private bool isEnd = false;
    //ｹﾞｰﾑ終了時に表示するﾃｷｽﾄ
    private GameObject stateText;
    //score
    private int score = 0;
    private GameObject scoreText;
    //左ボタン押下の判定
    private bool isLButtonDown = false;
    //右ボタン押下の判定
    private bool isRButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        //Animatorｺﾝﾎﾟｰﾈﾝﾄを取得
        this.myAnimator = GetComponent<Animator>();

        //走るｱﾆﾒｰｼｮﾝを開始
        this.myAnimator.SetFloat("Speed", 1);

        //Rigidbodyｺﾝﾎﾟｰﾈﾝﾄを取得
        myRigidbody = this.GetComponent<Rigidbody>();

        //ｼｰﾝ中のstateTextｵﾌﾞｼﾞｪｸﾄを取得
        this.stateText = GameObject.Find("GameResultText");

        //ｼｰﾝ中のscoreTextを取得
        this.scoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {
        //ｹﾞｰﾑ終了ならUnityちゃんの動きを減衰する
        if (this.isEnd)
        {
            this.forwardForce *= this.coefficient;
            this.turnForce *= this.coefficient;
            this.upForce *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }




        //Unityちゃんに前方向の力を加える
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);
        //引数は方向

        //矢印キー又はボタンに応じて左右に移動させる
        if((Input.GetKey(KeyCode.LeftArrow)||this.isLButtonDown)&&-this.movableRange < this.transform.position.x)
        {
            this.myRigidbody.AddForce(-this.turnForce, 0, 0);
        }else if((Input.GetKey(KeyCode.RightArrow)||this.isRButtonDown)&& this.movableRange > this.transform.position.x)     
        {
            this.myRigidbody.AddForce(this.turnForce, 0, 0);
        }

        //Jumpｽﾃｰﾄの場合はJumpにfalseをｾｯﾄする
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        //ｼﾞｬﾝﾌﾟしていない時にｽﾍﾟｰｽが押されたらｼﾞｬﾝﾌﾟする
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
        {
            //ｼﾞｬﾝﾌﾟｱﾆﾒｰｼｮﾝを再生
            this.myAnimator.SetBool("Jump", true);
            //Unityちゃんに上方向の力を加える
            this.myRigidbody.AddForce(this.transform.up * this.upForce);

        }
    }

    //ﾄﾘｶﾞｰﾓｰﾄﾞで他のｵﾌﾞｼﾞｪｸﾄと接触した場合の処理
    private void OnTriggerEnter(Collider other)
    {
       //障害物に衝突した場合
       if(other.gameObject.tag=="CarTag" || other.gameObject.tag == "TrafficConeTag") {
            this.isEnd = true;
            //stateTextにGAMEOVERを表示
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }

        //ゴール地点に到達した場合
        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            //stateTextにGAMECLEARを表示
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }
        //ｺｲﾝに衝突した場合
        if (other.gameObject.tag == "CoinTag")
        {
            score += 10;
            scoreText.GetComponent<Text>().text= "Score " + this.score + "pt";
            //ﾊﾟｰﾃｨｸﾙを再生
            GetComponent<ParticleSystem>().Play();
            //接触したｺｲﾝのｵﾌﾞｼﾞｪｸﾄを破棄
            Destroy(other.gameObject);
        }
    }
    //ｼﾞｬﾝﾌﾟボタンを押した場合の処理
    public void GetMyJumpButtonDown()
    {
        if (this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }
    //左ボタンを押し続けた場合の処理
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //左ボタンを離した場合の処理
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }
    //右ボタンを押し続けた場合の処理
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //左ボタンを離した場合の処理
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }


}
