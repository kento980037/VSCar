using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class koukokuButton : MonoBehaviour
{
    public GameObject eng_koukoku;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            eng_koukoku.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectMenuScene()
    {
        SceneManager.LoadScene("koukokuScene");
    }
}
