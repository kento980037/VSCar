using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    GameObject image_attention;
    GameObject text_attention;
    GameObject text_attention2;
    GameObject Title_eng;
    float time = 0;
    float alfa = 0.999f;
    float alfa_text = 1;


    // Start is called before the first frame update
    void Start()
    {
        this.image_attention = GameObject.Find("image_attention");
        this.text_attention = GameObject.Find("text_attention");
        this.text_attention2 = GameObject.Find("text_attention2");
        this.Title_eng = GameObject.Find("Title_eng");
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            Title_eng.SetActive(false);
        }

            time += Time.deltaTime;
        
        if(time>3.0f)
        {
            if(alfa_text>=0)
            {
                
                text_attention.GetComponent<Text>().color = new Color(text_attention.GetComponent<Text>().color.r, text_attention.GetComponent<Text>().color.g, text_attention.GetComponent<Text>().color.b, alfa_text);
                text_attention2.GetComponent<Text>().color = new Color(text_attention2.GetComponent<Text>().color.r, text_attention2.GetComponent<Text>().color.g, text_attention2.GetComponent<Text>().color.b, alfa_text);
                alfa_text -= 0.02f;
            }
            else if(alfa>=0.00001f)
            {
                alfa =alfa*alfa;
                image_attention.GetComponent<Image>().color = new Color(image_attention.GetComponent<Image>().color.r, image_attention.GetComponent<Image>().color.g, image_attention.GetComponent<Image>().color.b, alfa);
            }
            
        }
        if(alfa<0.1f&& Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("MenuScene");
        }
        else if (alfa > 0.01f && Input.GetMouseButtonUp(0))
        {
            alfa_text = 0;
            alfa = 0.0001f;
            text_attention.GetComponent<Text>().color = new Color(text_attention.GetComponent<Text>().color.r, text_attention.GetComponent<Text>().color.g, text_attention.GetComponent<Text>().color.b, alfa_text);
            text_attention2.GetComponent<Text>().color = new Color(text_attention2.GetComponent<Text>().color.r, text_attention2.GetComponent<Text>().color.g, text_attention2.GetComponent<Text>().color.b, alfa_text);
            image_attention.GetComponent<Image>().color = new Color(image_attention.GetComponent<Image>().color.r, image_attention.GetComponent<Image>().color.g, image_attention.GetComponent<Image>().color.b, alfa);

        }
    }
}
