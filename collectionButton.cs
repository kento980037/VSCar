using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectionButton : MonoBehaviour
{
    public GameObject eng_collection;
    // Start is called before the first frame update
    void Start()
    {
        if(Application.systemLanguage == SystemLanguage.Japanese)
        {
            eng_collection.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectMenuScene()
    {
        SceneManager.LoadScene("collectionScene");
    }
}
