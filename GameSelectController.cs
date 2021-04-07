using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelectController : MonoBehaviour
{
    public static int stage = 1;
    GameObject text_money;
    int coin;
    int i = 0;
    int[] stageclear = new int[6];//ステージ１をクリアしている場合は、stageclear[0]=1
    GameObject[] clearmark = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        this.coin = PlayerPrefs.GetInt("coin", 0);
        this.text_money = GameObject.Find("text_money");
        this.text_money.GetComponent<Text>().text = "" + coin;
        for (i = 0; i < 6; i++)
        {
            stageclear[i] = PlayerPrefs.GetInt("stageclear" + (i + 1), 0);
            this.clearmark[i] = GameObject.Find("clearmark" + (i + 1));
            if(stageclear[i]==0)
            {
                clearmark[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameScene1Transition()
    {
        stage = 1;
        SceneManager.LoadScene("hintScene");
        //SceneManager.LoadScene("GameScene1");
    }

    public void GameScene2Transition()
    {
        stage = 2;
        //SceneManager.LoadScene("GameScene2");
        SceneManager.LoadScene("hintScene");
    }

    public void GameScene3Transition()
    {
        stage = 3;
        //SceneManager.LoadScene("GameScene3");
        SceneManager.LoadScene("hintScene");
    }

    public void GameScene4Transition()
    {
        stage = 4;
        //SceneManager.LoadScene("GameScene4");
        SceneManager.LoadScene("hintScene");
    }

    public void GameScene5Transition()
    {
        stage = 5;
        // SceneManager.LoadScene("GameScene5");
        SceneManager.LoadScene("hintScene");
    }

    public void GameScene6Transition()
    {
        stage = 6;
        //SceneManager.LoadScene("GameScene6");
        SceneManager.LoadScene("hintScene");
    }

    public static int getStage()
    {
        return stage;
    }

}