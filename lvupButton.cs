using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvupButton : MonoBehaviour
{
    public GameObject eng_lvup;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            eng_lvup.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectMenuScene()
    {
        SceneManager.LoadScene("lvupScene");
    }
}
