using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class appleController : MonoBehaviour
{
    GameObject AoriCar;
    GameObject AorihpGauge;
    GameObject PlayerhpGauge;
    Animation rot_y;
    Behaviour h;
    float aoriHp;
    int appleLevel;
    // Start is called before the first frame update
    void Start()
    {
        this.AoriCar = GameObject.Find("AoriCar");
        this.AorihpGauge = GameObject.Find("AorihpGauge");
        this.PlayerhpGauge = GameObject.Find("PlayerhpGauge");
        rot_y = this.AoriCar.GetComponent<Animation>();
        this.appleLevel = PlayerPrefs.GetInt("appleLevel", 1);
        this.h = (Behaviour)GetComponent("Halo");
        if(appleLevel<=5)
        {
            h.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 p1 = transform.position;
        Vector3 p2 = this.AoriCar.transform.position;
        Vector3 dir = p1 - p2;
        float d = dir.magnitude;
        if (d < 2.7f)
        {
            DecreaseAoriHp(200);
            rot_y.Play();
            Destroy(gameObject);
            this.PlayerhpGauge.GetComponent<Image>().fillAmount += 0.02f;
            if(appleLevel==6)
            {
                this.PlayerhpGauge.GetComponent<Image>().fillAmount += 0.04f;
            }


        }
        else if (d > 500 && d < 1000)
        {
            Destroy(gameObject);
        }
        else if (d >= 1000)
        {
            transform.position = new Vector3(this.AoriCar.transform.position.x, this.AoriCar.transform.position.y, this.AoriCar.transform.position.z + 1100);
        }

        void DecreaseAoriHp(float n)
        {
            if (SceneManager.GetActiveScene().name == "GameScene1")
            {
                aoriHp = 100f;
            }
            else if (SceneManager.GetActiveScene().name == "GameScene2")
            {
                aoriHp = 200f;
            }
            else if (SceneManager.GetActiveScene().name == "GameScene3")
            {
                aoriHp = 300f;
            }
            else if (SceneManager.GetActiveScene().name == "GameScene4")
            {
                aoriHp = 400f;
            }
            else if (SceneManager.GetActiveScene().name == "GameScene5")
            {
                aoriHp = 600f;
            }
            else if (SceneManager.GetActiveScene().name == "GameScene6")
            {
                aoriHp = 750f;
            }
            this.AorihpGauge.GetComponent<Image>().fillAmount -= 0.01f * n/aoriHp *appleLevel;
        }
    }

}

