using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AoriController : MonoBehaviour
{
    float movePower = 0.08f;
    public GameObject camera1;
    public GameObject PlayerhpGauge;
    public GameObject Explosion;
    public GameObject AorihpGauge;
    public GameObject klaxon;
    public GameObject can;
    public GameObject light1;
    public GameObject light2;
    public GameObject bullet;
    public GameObject gun;
    public GameObject banana_Buttom;
    public GameObject apple_Buttom;
    public GameObject pineapple_Buttom;
    public GameObject rockButton;
    float i;
    float tmp_time = 1.0f;
    float tmp_time2 = 0.0f;
    float tmp_time3 = 0;//あおり運転者の車間距離が短い時間を計測
    float tmp_time4 = 0;//プレイヤーがアイテムを投げたときのあおり運転がする動作を計測する時間
    float tmp_time5 = 0; //蛇行時間の計測
    float tmp_time6 = 0;//stage6でのそれぞれのぶきの確立を切り替える時間
    float p_klaxon = 0.07f;
    float p_can = 0.3f;
    float p_light = 0.3f;
    float p_gun = 0.1f;
    int i_aoriback = 0;//この値が１だと車間距離が短い時間がある時間を超えてバックする状態
    int i_aorikaihi = 0; //プレイヤーが何かアイテムを投げたとき、１だと何もしない、２だと右に逃げる、３だと左に投げる
    int i_aoridakou = 0;//蛇行運転する際、０だとまっすぐ、１だと右へ蛇行、２だと左へ蛇行
    int i_light = 1;
    int i_gun = 0;
    int i_stage6 = 0;//ステージ６を動かす変数。０だとノーマルモード、１だと少し怒りモード、２だと激おこモード
    int i_clear = 0;//1度だけ爆発させるための変数

    void Start()
    {
        /*
        this.camera1 = GameObject.Find("Main Camera");
        this.Explosion = GameObject.Find("Explosion");
        this.AorihpGauge = GameObject.Find("AorihpGauge");
        this.PlayerhpGauge = GameObject.Find("PlayerhpGauge");
        if (SceneManager.GetActiveScene().name == "GameScene2" || SceneManager.GetActiveScene().name == "GameScene6")
        {
            this.klaxon = GameObject.Find("klaxon");
        }
        if (SceneManager.GetActiveScene().name == "GameScene3"|| SceneManager.GetActiveScene().name == "GameScene6")
        {
            this.can = GameObject.Find("can");
        }
        if (SceneManager.GetActiveScene().name == "GameScene4"|| SceneManager.GetActiveScene().name == "GameScene6")
        {
            this.light1 = GameObject.Find("headlight");
            this.light2 = GameObject.Find("headlight2");
        }
        if (SceneManager.GetActiveScene().name == "GameScene5"|| SceneManager.GetActiveScene().name == "GameScene6")
        {
            this.bullet = GameObject.Find("bullet");
            this.gun = GameObject.Find("gun");
        }
        this.banana_Buttom = GameObject.Find("bananaButtom");
        this.apple_Buttom = GameObject.Find("appleButtom");
        this.pineapple_Buttom = GameObject.Find("pineappleButtom");
        this.rockButton = GameObject.Find("rockButtom");
        */

        if (SceneManager.GetActiveScene().name == "GameScene6")
        {
            p_klaxon = 0;
            p_can = 0;
            p_light = 0;
            p_gun = 0;
            gun.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "GameScene5")
        {
            gun.SetActive(false);
        }   
    }

    void FixedUpdate()
    {
        if(i_clear==0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }

        Vector3 cameraPos = this.camera1.transform.position;
        if (transform.position.x- cameraPos.x>0)//車に合わせて煽り運転車も左右に移動
        {
            this.movePower = (transform.position.x - cameraPos.x)/100;
            Left();
        }
        else if(transform.position.x - cameraPos.x < 0)
        {
            this.movePower = (- transform.position.x + cameraPos.x)/100;
            Right();
        }



        //以下あおり運転の攻撃アルゴリズム

        i = Random.Range(0, 1000)*0.02f;//乱数変数を用意0~20

        //ランダムで車間距離を詰める
        if(this.AorihpGauge.GetComponent<Image>().fillAmount<0.5f && (SceneManager.GetActiveScene().name == "GameScene1" || SceneManager.GetActiveScene().name == "GameScene5" || SceneManager.GetActiveScene().name == "GameScene6"))//stage１、５、６でHpが少ないときは車間距離を詰めるスピードが高め
        {
            if (1.5f < i && i < 0.9f + (transform.position.z - this.camera1.transform.position.z) / 5.0f)
            {
                
                if (transform.position.z - this.camera1.transform.position.z > 3)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.12f);
                    if(SceneManager.GetActiveScene().name == "GameScene5")
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
                    }
                }
            }
        }
        else if(transform.position.z - this.camera1.transform.position.z>50 && (SceneManager.GetActiveScene().name == "GameScene4"|| SceneManager.GetActiveScene().name == "GameScene6"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.8f);
        }
        else
        {
            if (1.8f < i && i < 1.5f + (transform.position.z - this.camera1.transform.position.z) / 9.0f)
            {
                if (transform.position.z - this.camera1.transform.position.z > 3)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
                    if (SceneManager.GetActiveScene().name == "GameScene5" || SceneManager.GetActiveScene().name == "GameScene4")
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.06f);
                    }
                }
                
            }
        }


        //stage6での特別アルゴリズム
        if(SceneManager.GetActiveScene().name == "GameScene6")
        {
            tmp_time6 += Time.deltaTime;
            if(tmp_time6>3)
            {
                if(i_stage6==0)
                {
                    p_klaxon = 0.1f;
                    p_can = 0;
                    p_light = 0;
                    p_gun = 0.08f;
                }
                else if(i_stage6 == 1)
                {
                    p_klaxon = 0.05f;
                    p_can = 0.7f;
                    p_light = 0;
                    p_gun = 0;
                }
                else if(i_stage6 == 2)
                {
                    p_klaxon = 0.02f;
                    p_can = 0.02f;
                    p_light = 0.5f;
                    p_gun = 0.35f;
                }
                tmp_time6 = 0;
            }
            if(this.AorihpGauge.GetComponent<Image>().fillAmount < 0.8f && i_stage6==0)
            {
                i_stage6 = 1;
            }
            else if(this.AorihpGauge.GetComponent<Image>().fillAmount < 0.4f && i_stage6==1)
            {
                i_stage6 = 2;
            }
        }


        //車間距離が短い時間が長くなったら一度バックする
        if(transform.position.z - this.camera1.transform.position.z<13 && i_aoriback==0)
        {
            tmp_time3 += Time.deltaTime;
        }
        if(tmp_time3>10.0f)
        {
            i_aoriback = 1;
            tmp_time3 = 0;
        }
        if(i_aoriback==1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.2f);
            if(transform.position.z - this.camera1.transform.position.z > 30)
            {
                i_aoriback = 0;
            }
        }


        //プレイヤーが何かアイテムを投げたら避ける
        if(i_aorikaihi==0)
        {
            if((this.banana_Buttom.GetComponent<Image>().fillAmount<0.001f && this.apple_Buttom.GetComponent<Image>().fillAmount > 0.001f )|| (this.apple_Buttom.GetComponent<Image>().fillAmount < 0.001f && this.pineapple_Buttom.GetComponent<Image>().fillAmount > 0.001f) || (this.pineapple_Buttom.GetComponent<Image>().fillAmount < 0.001f && this.banana_Buttom.GetComponent<Image>().fillAmount > 0.001f))
            {
                if(SceneManager.GetActiveScene().name == "GameScene2")
                {
                    i_aorikaihi = Random.Range(1, 6);
                }
                else if(SceneManager.GetActiveScene().name == "GameScene3")
                {
                    i_aorikaihi = Random.Range(1, 5);
                }
                else if(SceneManager.GetActiveScene().name == "GameScene4")
                {
                    i_aorikaihi = Random.Range(1, 4);
                }
                else
                {
                    i_aorikaihi = Random.Range(6,8);
                }
            }
        }
        else if(i_aorikaihi==1 || i_aorikaihi==4 || i_aorikaihi==5 || i_aorikaihi==6)
        {
            tmp_time4 += Time.deltaTime;
        }
        else if(i_aorikaihi==2)
        {
            tmp_time4 += Time.deltaTime;
            if(transform.position.x<4.799f)
            {
                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            }
        }
        else if (i_aorikaihi == 3)
        {
            tmp_time4 += Time.deltaTime;
            if(transform.position.x>-4.799f)
            {
                transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
            }
        }
        else if(i_aorikaihi==7)
        {
            tmp_time4 += Time.deltaTime;
            if ( transform.position.x < 4.799f && transform.position.x > -4.799f)
            {
                if(transform.position.x - this.camera1.transform.position.x>0)
                {
                    if(i_gun==0)
                    {
                        transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
                    }
                }
                else
                {
                    if (i_gun == 0)
                    {
                        transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
                    }
                }
            }
        }
        if(tmp_time4>=0.3f)
        {
            i_aorikaihi = 0;
            tmp_time4 = 0;
        }




        //stage2,stage6ではクラクションを生成
        if (3<i&&i<3+p_klaxon && (SceneManager.GetActiveScene().name == "GameScene2"|| SceneManager.GetActiveScene().name == "GameScene6"))
        {
            xlaxonGenerate();
        }

        //stage3,6では空き缶を生成
        if (4 < i && i < 4+p_can && (SceneManager.GetActiveScene().name == "GameScene3" || SceneManager.GetActiveScene().name == "GameScene6"))
        {
            canGenerate();
        }

        //stage4,6ではハイビームを生成
        if(5<i&&i<5+p_light && (SceneManager.GetActiveScene().name == "GameScene4" || SceneManager.GetActiveScene().name == "GameScene6"))
        {
            if(i_light==0)
            {
                light1.SetActive(true);
                light2.SetActive(true);
                i_light = 1;
            }
        }
        if(i_light==1 && (SceneManager.GetActiveScene().name == "GameScene4" || SceneManager.GetActiveScene().name == "GameScene6"))
        {
            tmp_time += Time.deltaTime;
            if(tmp_time>=0.35f)
            {
                i_light = 0;
                tmp_time = 0;
                light1.SetActive(false);
                light2.SetActive(false);
            }
            else if(Mathf.Abs(transform.position.x-this.camera1.transform.position.x)<2 && (this.rockButton.GetComponent<Image>().fillAmount <= 0.001f || this.rockButton.GetComponent<Image>().fillAmount >= 0.999f))
            {
                this.PlayerhpGauge.GetComponent<Image>().fillAmount -= 0.0025f;
            }
        }

        //stage5,6ではエアガンを生成
        if (6 < i && i < 6+p_gun && (SceneManager.GetActiveScene().name == "GameScene5" || SceneManager.GetActiveScene().name == "GameScene6") && i_gun==0)
        {
            gun.SetActive(true);
            i_gun = 1;
        }
        if (i_gun == 1 && (SceneManager.GetActiveScene().name == "GameScene5" || SceneManager.GetActiveScene().name == "GameScene6"))
        {
            tmp_time2 += Time.deltaTime;
            if (tmp_time2 >= 0.8f)
            {
                bulletGenerate();
                i_gun = 0;
                tmp_time2 = 0;
                gun.SetActive(false);
            }
        }

        //ランダムで左右に移動
        if(7<i && i<7.2 && i_aoridakou==0)
        {
            i_aoridakou = Random.Range(1, 3);
        }
        if(i_aoridakou==1)
        {
            tmp_time5 += Time.deltaTime;
            if (transform.position.x < 4.799f)
            {
                transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);
            }
        }
        if(i_aoridakou==2)
        {
            tmp_time5 += Time.deltaTime;
            if (transform.position.x > -4.799f)
            {
                transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y, transform.position.z);
            }
        }
        if(tmp_time5>=4.0f)
        {
            i_aoridakou = 0;
            tmp_time5 = 0;
        }

        //煽り運転のhpがゼロになったら爆発エフェクトとクリアシーンへの遷移
        if (this.AorihpGauge.GetComponent<Image>().fillAmount <=0 && i_clear==0)//爆発エフェクトを実行し、クリア画面へ移動
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Invoke("GameClear", 1);
            i_clear++;
        }

    }

    void Right()
    {
        if (transform.position.x <= 5f)
        {
            Vector3 temp = new Vector3(transform.position.x + movePower, transform.position.y, transform.position.z);
            transform.position = temp;
        }
    }

    void Left()
    {
        if (transform.position.x >= -5f)
        {
            Vector3 temp = new Vector3(transform.position.x - movePower, transform.position.y, transform.position.z);
            transform.position = temp;
        }
    }

    void GameClear()
    {
        SceneManager.LoadScene("ClearScene");
    }

    void xlaxonGenerate()
    {
        GameObject instant = Instantiate(klaxon) as GameObject;
        instant.transform.position = new Vector3(transform.position.x, transform.position.y+3, transform.position.z);
    }

    void canGenerate()
    {
        GameObject instant = Instantiate(can) as GameObject;
        instant.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        Rigidbody rb = instant.GetComponent<Rigidbody>();  // rigidbodyを取得
        Vector3 force = new Vector3(0.0f, 30.0f, 0.0f);    // 力を設定
        rb.AddForce(force, ForceMode.Force);  // 力を加える
    }

    void lightGenerate()
    {
        if(tmp_time>=1.0f)
        {
            light1.SetActive(false);
            light2.SetActive(false);
            tmp_time = 0;
        }
        else
        {
            light1.SetActive(true);
            light2.SetActive(true);
            tmp_time += Time.deltaTime;
        }
    }
    void bulletGenerate()
    {
        GameObject instant = Instantiate(bullet) as GameObject;
        instant.transform.position = new Vector3(transform.position.x-0.8f, transform.position.y + 1.0f, transform.position.z);
    }
}
