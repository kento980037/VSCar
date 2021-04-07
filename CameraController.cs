using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public GameObject AoriCar;
    public GameObject course1;
    public GameObject course2;
    public GameObject banana;
    public GameObject apple;
    public GameObject pineapple;
    public GameObject PlayerhpGauge;
    public GameObject startText;
    public GameObject banana_Buttom;
    public GameObject apple_Buttom;
    public GameObject pineapple_Buttom;
    public GameObject rockButton;
    public GameObject rockNumber;
    public GameObject pauseback;
    ParticleSystem attention;
    int border = -1000;
    int i_text = 0;//あおり運転者が近づいた時に１度だけコメントを表示するための変数
    int rocknumber = 0;
    int pineappleLevel = 1;
    float movePower = 0.2f;

    float second = 0;//イライラのパーティクルを実行するための時間変数
    int i_attention = 0;//イライラのパーティクルを実行する変数

    float tmp_playerHp = 1.0f;

    [SerializeField] RenderTexture normalTexture=default;//インスペクター上から設定しましょう
    [SerializeField] RenderTexture rockTexture=default;//インスペクター上から設定しましょう
    public GameObject RawImage;
    public GameObject RawImageRock;

    void Start()
    {
        /*
        this.AoriCar = GameObject.Find("AoriCar");
        this.course1 = GameObject.Find("Course1");
        this.course2 = GameObject.Find("Course2");
        this.banana = GameObject.Find("banana");
        this.apple = GameObject.Find("apple");
        this.pineapple = GameObject.Find("pineapple");
        this.PlayerhpGauge = GameObject.Find("PlayerhpGauge");
        this.banana_Buttom = GameObject.Find("bananaButtom");
        this.apple_Buttom = GameObject.Find("appleButtom");
        this.rockButton = GameObject.Find("rockButtom");
        this.rockNumber = GameObject.Find("rockNumber");
        this.pineapple_Buttom = GameObject.Find("pineappleButtom");
        this.startText = GameObject.Find("Text");
        */
        this.startText.GetComponent<Text>().text = "後ろにあおり運転車が現れた！！";
        if (Application.systemLanguage != SystemLanguage.Japanese)
        {
            this.startText.GetComponent<Text>().text = "The car behind you is tailgating you!!";
        }

        attention = this.GetComponent<ParticleSystem>();
        Vector3 AoriCarPos = this.AoriCar.transform.position;
        transform.position = new Vector3(AoriCarPos.x-3, transform.position.y, AoriCarPos.z - 30);

        this.rocknumber = PlayerPrefs.GetInt("block", 0);
        this.rockNumber.GetComponent<Text>().text = ""+rocknumber;
        if (rocknumber==0)
        {
            this.rockButton.GetComponent<Image>().fillAmount = 0;
            rockNumber.SetActive(false);
        }


        //this.RawImage = GameObject.Find("RawImage");
        //this.RawImageRock = GameObject.Find("RawImageRock");
        RawImageRock.SetActive(false);
        this.GetComponent<Camera>().targetTexture = normalTexture;

        this.pineappleLevel = PlayerPrefs.GetInt("pineappleLevel", 1);

        //this.pauseback = GameObject.Find("pauseback");
        pauseback.SetActive(false);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);

        if (transform.position.z < border)
        {
            CreateMap();
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            Right();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Left();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            bananaGenerate();
        }

        if (tmp_playerHp - this.PlayerhpGauge.GetComponent<Image>().fillAmount > 0)
        {
            tmp_playerHp = this.PlayerhpGauge.GetComponent<Image>().fillAmount;
            var emission = attention.emission;
            emission.rateOverTime = 20;
            //attention.Play();
            i_attention = 1;
            if(second==0)
            {
                attention.Play();
            }
        }
        if (i_attention == 1)
        { 
            second += Time.deltaTime;
            if (second >= 1.0f)
            {
                attention.Stop();
                i_attention = 0;
                second = 0;
            }
        }
        if ((this.AoriCar.transform.position.z- transform.position.z<15)&&Mathf.Abs(this.AoriCar.transform.position.x - transform.position.x)< 2 && (this.rockButton.GetComponent<Image>().fillAmount<=0.001f || this.rockButton.GetComponent<Image>().fillAmount>=0.999f))
        {
            float n;
            n = 16.0f - (this.AoriCar.transform.position.z - transform.position.z);
            n =n*2;
            this.PlayerhpGauge.GetComponent<Image>().fillAmount -= 0.00015f * n;
            if (i_text==0)
            {
                this.startText.GetComponent<Text>().text = "危険！車間距離が近い！";//スタートテキストの使い回し
                if (Application.systemLanguage != SystemLanguage.Japanese)
                {
                    this.startText.GetComponent<Text>().text = "Watch out! The distance between cars is very short!";
                }
                this.startText.transform.position = new Vector3(3500, this.startText.transform.position.y, this.startText.transform.position.z);
                i_text++;
            }
        }
        else
        {
            i_text = 0;
        }


        if(this.PlayerhpGauge.GetComponent<Image>().fillAmount <=0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        
        if (this.startText.transform.position.x > -4000)//テキストを流す
        {
            this.startText.transform.position = new Vector3(this.startText.transform.position.x - 1000 * Time.deltaTime, this.startText.transform.position.y, this.startText.transform.position.z);
        }

        if (this.banana_Buttom.GetComponent<Image>().fillAmount < 1)
        {
            this.banana_Buttom.GetComponent<Image>().fillAmount += 0.005f;
        }

        if (this.apple_Buttom.GetComponent<Image>().fillAmount < 1)
        {
            this.apple_Buttom.GetComponent<Image>().fillAmount += 0.02f;
        }
        if (this.pineapple_Buttom.GetComponent<Image>().fillAmount < 1)
        {
            this.pineapple_Buttom.GetComponent<Image>().fillAmount += 0.001f;
        }

        if(this.rockButton.GetComponent<Image>().fillAmount <0.99f && rocknumber>=1)
        {
            this.rockButton.GetComponent<Image>().fillAmount += 0.01f;
            if(this.rockButton.GetComponent<Image>().fillAmount >= 0.99f)
            {
                rocknumber -= 1;
                PlayerPrefs.SetInt("block", rocknumber);
                PlayerPrefs.Save();
                this.rockNumber.GetComponent<Text>().text = "" + rocknumber;
                this.GetComponent<Camera>().targetTexture = normalTexture;
                this.RawImage.SetActive(true);
                this.RawImageRock.SetActive(false);
            }
           
        }
    }

    void CreateMap()
    {
        if (this.course1.transform.position.z > border)
        {
            border -= 2000;
            Vector3 temp = new Vector3(0, 0.05f, border);
            this.course1.transform.position = temp;
        }
        else if (this.course2.transform.position.z > border)
        {
            border -= 2000;
            Vector3 temp = new Vector3(0, 0.05f, border);
            this.course2.transform.position = temp;
        }
    }

    public void Right()
    {
        if (transform.position.x <= 5f)
        {
            Vector3 temp = new Vector3(transform.position.x + movePower, transform.position.y, transform.position.z);
            transform.position = temp;
        }
    }

    public void Left()
    {
        if (transform.position.x >= -5f)
        {
            Vector3 temp = new Vector3(transform.position.x - movePower, transform.position.y, transform.position.z);
            transform.position = temp;
        }
    }

    public void bananaButtomDown()
    {
        if (this.banana_Buttom.GetComponent<Image>().fillAmount >= 0.99f)
        {
            bananaGenerate();
        }
    }

    void bananaGenerate()
    {
        GameObject instant = Instantiate(banana) as GameObject;
        instant.transform.position= new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z-3);
        this.banana_Buttom.GetComponent<Image>().fillAmount = 0;
    }

    public void appleButtomDown()
    {
        if (this.apple_Buttom.GetComponent<Image>().fillAmount >= 0.99f)
        {
            appleGenerate();
        }
    }

    void appleGenerate()
    {
        GameObject instant = Instantiate(apple) as GameObject;
        instant.transform.position = new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z-3);
        this.apple_Buttom.GetComponent<Image>().fillAmount = 0;
    }

    public void pineappleButtomDown()
    {
        if (this.pineapple_Buttom.GetComponent<Image>().fillAmount >= 0.99f)
        {
            pineappleGenerate();
        }
    }

    void pineappleGenerate()
    {
        GameObject instant = Instantiate(pineapple) as GameObject;
        if(pineappleLevel<=5)
        {
            instant.transform.position = new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z-3);
        }
        else if(pineappleLevel==6)
        {
            instant.transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z-8 );
        }
        this.pineapple_Buttom.GetComponent<Image>().fillAmount = 0;
    }

    public void blockButton()
    {
        if (this.rockButton.GetComponent<Image>().fillAmount >= 0.99f && rocknumber>=1)
        {
            this.rockButton.GetComponent<Image>().fillAmount = 0;
            this.GetComponent<Camera>().targetTexture = rockTexture;
            this.RawImage.SetActive(false);
            this.RawImageRock.SetActive(true);
        }
    }

    public void pauseButton()
    {
        Time.timeScale = 0;
        pauseback.SetActive(true);
    }

    public void unpauseButton()
    {
        Time.timeScale = 1;
        pauseback.SetActive(false);
    }

    public void menubackbutton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
