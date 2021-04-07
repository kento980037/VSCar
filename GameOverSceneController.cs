using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour
{
    float time=0;
    // Start is called before the first frame update
    void Start()
    {
        
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
