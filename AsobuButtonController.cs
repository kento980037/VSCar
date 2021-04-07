using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsobuButtonController : MonoBehaviour
{
    GameObject text_money;
    public GameObject eng_asobu;
    int coin;
    // Start is called before the first frame update
    void Start()
    {
        this.coin = PlayerPrefs.GetInt("coin", 0);
        this.text_money = GameObject.Find("text_money");
        this.text_money.GetComponent<Text>().text = "" + coin;

        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            eng_asobu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectMenuScene()
    {
        SceneManager.LoadScene("GameSelectScene");
    }
}
