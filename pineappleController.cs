using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pineappleController : MonoBehaviour
{
    GameObject AoriCar;
    GameObject AorihpGauge;
    Animation rot_y;
    Behaviour h;
    float aoriHp;
    int pineappleLevel;
    // Start is called before the first frame update
    void Start()
    {
        this.pineappleLevel = PlayerPrefs.GetInt("pineappleLevel", 1);
        this.AoriCar = GameObject.Find("AoriCar");
        this.AorihpGauge = GameObject.Find("AorihpGauge");
        rot_y = this.AoriCar.GetComponent<Animation>();
        this.h = (Behaviour)GetComponent("Halo");
        if (pineappleLevel <= 5)
        {
            h.enabled = false;
        }
        if (pineappleLevel==6)
        {
            transform.localScale = new Vector3(100,100,100);
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(-90,90));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 p1 = transform.position;
        Vector3 p2 = this.AoriCar.transform.position;
        Vector3 dir = p1 - p2;
        float d = dir.magnitude;
        if (pineappleLevel <= 5)
        {
            if (d < 2.7f)
            {
                DecreaseAoriHp(3200);
                rot_y.Play();
                Destroy(gameObject);
            }
            else if (d > 500 && d < 1000)
            {
                Destroy(gameObject);
            }
            else if (d >= 1000)
            {
                transform.position = new Vector3(this.AoriCar.transform.position.x, this.AoriCar.transform.position.y, this.AoriCar.transform.position.z + 1100);
            }
        }
        else if(pineappleLevel==6)
        {
            if(transform.position.z-this.AoriCar.transform.position.z<0.5f && transform.position.z - this.AoriCar.transform.position.z>-0.5f)
            {
                DecreaseAoriHp(3000);
                rot_y.Play();
                Destroy(gameObject);
            }
            else if (d > 500 && d < 1000)
            {
                Destroy(gameObject);
            }
            else if (d >= 1000)
            {
                transform.position = new Vector3(this.AoriCar.transform.position.x, this.AoriCar.transform.position.y, this.AoriCar.transform.position.z + 1100);
            }
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
            this.AorihpGauge.GetComponent<Image>().fillAmount -= 0.01f * n/aoriHp * pineappleLevel;
        }

    }
}
