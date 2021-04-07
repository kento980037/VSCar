using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearSceneController : MonoBehaviour
{
    GameObject Text_getcoin;
    GameObject Text_getcollection;
    GameObject stareffect;
    ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();

    int i;
    int stage_ = 1;
    int coin;
    int[] stageclear=new int [6];//ステージ１をクリアしている場合は、stageclear[0]=1
    int[] collection = new int[15];//コレクション１を持っている場合は、colllection[0]=1
    float time = 0;//画面遷移がすぐに起きないための時間変数
    float p_collection = 0;//コレクションの確率変数(0~1)

    // Start is called before the first frame update
    void Start()
    {
        this.Text_getcoin = GameObject.Find("Text_getcoin");
        this.Text_getcollection = GameObject.Find("Text_getcollection");
        stage_ = GameSelectController.getStage();
        coin = PlayerPrefs.GetInt("coin", 0);//コインのロード
        for(i=0;i<6;i++)
        {
            stageclear[i]= PlayerPrefs.GetInt("stageclear"+(i+1),0);
        }
        for (i = 0; i < 15; i++)
        {
            collection[i] = PlayerPrefs.GetInt("collection" + (i + 1), 0);
        }
        p_collection = Random.Range(0, 1.0f);

        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            if (stage_ == 1)
            {
                coin += 5;
                stageclear[0] = 1;
                this.Text_getcoin.GetComponent<Text>().text = "・5コイン獲得！！";
                if (p_collection < 0.8f)
                {
                    if (collection[0] == 0)
                    {
                        collection[0] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「タイヤ」を獲得！！";
                    }
                }
                else
                {
                    if (collection[1] == 0)
                    {
                        collection[1] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「サイドミラー」を獲得！！";
                    }
                }
            }
            else if (stage_ == 2)
            {
                coin += 10;
                stageclear[1] = 1;
                this.Text_getcoin.GetComponent<Text>().text = "・10コイン獲得！！";
                if (p_collection < 0.8f)
                {
                    if (collection[2] == 0)
                    {
                        collection[2] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「バッテリー」を獲得！！";
                    }
                }
                else
                {
                    if (collection[3] == 0)
                    {
                        collection[3] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「ハンドル」を獲得！！";
                    }
                }
            }
            else if (stage_ == 3)
            {
                coin += 15;
                stageclear[2] = 1;
                this.Text_getcoin.GetComponent<Text>().text = "・15コイン獲得！！";
                if (p_collection < 0.8f)
                {
                    if (collection[4] == 0)
                    {
                        collection[4] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「カーナビ」を獲得！！";
                    }
                }
                else
                {
                    if (collection[5] == 0)
                    {
                        collection[5] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「ナンバープレート」を獲得！！";
                    }
                }
            }
            else if (stage_ == 4)
            {
                coin += 20;
                stageclear[3] = 1;
                this.Text_getcoin.GetComponent<Text>().text = "・20コイン獲得！！";
                if (p_collection < 0.8f)
                {
                    if (collection[6] == 0)
                    {
                        collection[6] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「スピードメーター」を獲得！！";
                    }
                }
                else
                {
                    if (collection[7] == 0)
                    {
                        collection[7] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「ドライブレコーダー」を獲得！！";
                    }
                }
            }
            else if (stage_ == 5)
            {
                coin += 25;
                stageclear[4] = 1;
                this.Text_getcoin.GetComponent<Text>().text = "・25コイン獲得！！";
                if (p_collection < 0.8f)
                {
                    if (collection[8] == 0)
                    {
                        collection[8] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「スマホ」を獲得！！";
                    }
                }
                else if (p_collection >= 0.8f && p_collection < 0.95f)
                {
                    if (collection[9] == 0)
                    {
                        collection[9] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「お酒」を獲得！！";
                    }
                }
                else
                {
                    if (collection[10] == 0)
                    {
                        collection[10] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「信号機」を獲得！！";
                    }
                }
            }
            else if (stage_ == 6)
            {
                coin += 30;
                stageclear[5] = 1;
                this.Text_getcoin.GetComponent<Text>().text = "・30コイン獲得！！";
                if (coin > 600 && collection[10] == 1 && p_collection < 0.1f)
                {
                    if (collection[14] == 0)
                    {
                        collection[14] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「タピのみ」を獲得！！";
                    }
                }
                else if (p_collection < 0.8f)
                {
                    if (collection[11] == 0)
                    {
                        collection[11] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「自転車」を獲得！！";
                    }
                }
                else if (p_collection >= 0.8f && p_collection < 0.99f)
                {
                    if (collection[12] == 0)
                    {
                        collection[12] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「自動運転」を獲得！！";
                    }
                }
                else
                {
                    if (collection[13] == 0)
                    {
                        collection[13] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・コレクション「思いやり」を獲得！！";
                    }
                }
            }
        }
        else //以下は英語ver
        {
            if (stage_ == 1)
            {
                coin += 5;
                stageclear[0] = 1;
                this.Text_getcoin.GetComponent<Text>().text = "・You get 5 coins!!";
                if (p_collection < 0.8f)
                {
                    if (collection[0] == 0)
                    {
                        collection[0] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item ,Tire!!";
                    }
                }
                else
                {
                    if (collection[1] == 0)
                    {
                        collection[1] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Side view mirror!!";
                    }
                }
            }
            else if (stage_ == 2)
            {
                coin += 10;
                stageclear[1] = 1;
                this.Text_getcoin.GetComponent<Text>().text = "・You get 10 coins！！";
                if (p_collection < 0.8f)
                {
                    if (collection[2] == 0)
                    {
                        collection[2] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Battery!!";
                    }
                }
                else
                {
                    if (collection[3] == 0)
                    {
                        collection[3] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Steering wheel!!";
                    }
                }
            }
            else if (stage_ == 3)
            {
                coin += 15;
                stageclear[2] = 1;
                this.Text_getcoin.GetComponent<Text>().text = "・You get 15 coins！！";
                if (p_collection < 0.8f)
                {
                    if (collection[4] == 0)
                    {
                        collection[4] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Car navigation system!!";
                    }
                }
                else
                {
                    if (collection[5] == 0)
                    {
                        collection[5] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Number plate!!";
                    }
                }
            }
            else if (stage_ == 4)
            {
                coin += 20;
                stageclear[3] = 1;
                this.Text_getcoin.GetComponent<Text>().text = "・You get 20 coins!!";
                if (p_collection < 0.8f)
                {
                    if (collection[6] == 0)
                    {
                        collection[6] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Speedometer!!";
                    }
                }
                else
                {
                    if (collection[7] == 0)
                    {
                        collection[7] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Dash cam!!";
                    }
                }
            }
            else if (stage_ == 5)
            {
                coin += 25;
                stageclear[4] = 1;
                this.Text_getcoin.GetComponent<Text>().text = "・You get 25 coins!!";
                if (p_collection < 0.8f)
                {
                    if (collection[8] == 0)
                    {
                        collection[8] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Smartphone!!";
                    }
                }
                else if (p_collection >= 0.8f && p_collection < 0.95f)
                {
                    if (collection[9] == 0)
                    {
                        collection[9] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Alcoholic beverage!!";
                    }
                }
                else
                {
                    if (collection[10] == 0)
                    {
                        collection[10] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Traffic light!!";
                    }
                }
            }
            else if (stage_ == 6)
            {
                coin += 30;
                stageclear[5] = 1;
                this.Text_getcoin.GetComponent<Text>().text = "・You get 30 coins!!";
                if (coin > 600 && collection[10] == 1 && p_collection < 0.1f)
                {
                    if (collection[14] == 0)
                    {
                        collection[14] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Tapinomi!!";
                    }
                }
                else if (p_collection < 0.8f)
                {
                    if (collection[11] == 0)
                    {
                        collection[11] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Bycycle!!";
                    }
                }
                else if (p_collection >= 0.8f && p_collection < 0.99f)
                {
                    if (collection[12] == 0)
                    {
                        collection[12] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Autonomous car!!";
                    }
                }
                else
                {
                    if (collection[13] == 0)
                    {
                        collection[13] = 1;
                        this.Text_getcollection.GetComponent<Text>().text = "・You get the collection item, Consideration!!";
                    }
                }
            }
        }

        



        PlayerPrefs.SetInt("coin", coin);
        for (i = 0; i < 6; i++)
        {
            PlayerPrefs.SetInt("stageclear"+(i+1), stageclear[i]);
        }
        for(i=0;i<15;i++)
        {
            PlayerPrefs.SetInt("collection" + (i + 1), collection[i]);
        }
        PlayerPrefs.Save();

        
        this.stareffect = GameObject.Find("stareffect");
        emitParams.applyShapeToPosition = true;
        emitParams.position = new Vector3(emitParams.position.x, emitParams.position.y + 1000, emitParams.position.z + 1000);//なぜだか分からないが最初のエフェクトは拡散しないで汚いのでこ２行でに見えないところで飛ばす
        stareffect.GetComponent<ParticleSystem>().Emit(emitParams, 1);
        emitParams.position = Text_getcoin.transform.position;
        emitParams.position = new Vector3(emitParams.position.x-10, emitParams.position.y, emitParams.position.z-90);
        for(i=0;i<7;i++)
        {
            emitParams.position = new Vector3(emitParams.position.x+5, emitParams.position.y, emitParams.position.z);
            stareffect.GetComponent<ParticleSystem>().Emit(emitParams, 30);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(time<1.0f)
        {
            time += Time.deltaTime;
            
        }
        if (Input.GetMouseButtonUp(0) && time>=1.0f)
        {
            SceneManager.LoadScene("GameSelectScene");
        }
    }
}
