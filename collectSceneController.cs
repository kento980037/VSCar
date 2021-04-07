using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collectSceneController : MonoBehaviour
{
	int i;
	int coin;
	GameObject text_money;
	GameObject[] collectionArray = new GameObject[15];
	int[] collection = new int[15];//コレクション１を持っている場合は、colllection[0]=1
    public static int collect=1;//説明画面にいく際にどのコレクションかを判別するための変数
    public ScrollRect scrollRect;
    public static float pos=1.0f;


// Start is called before the first frame update
	void Start()
    {
        pos= collectSceneController.getPos();
        scrollRect.verticalNormalizedPosition = pos;
		this.coin = PlayerPrefs.GetInt("coin", 0);
		this.text_money = GameObject.Find("text_money");
		this.text_money.GetComponent<Text>().text = "" + coin;

		for (i = 0; i < 15; i++)
		{
            collection[i] = PlayerPrefs.GetInt("collection" + (i + 1), 0);
            this.collectionArray[i] = GameObject.Find("collection" + (i + 1));
            if(collection[i]==0)
			{
				collectionArray[i].SetActive(false);
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collectiontell(int collectnumber)
    {
        switch (collectnumber)
        {
            case 1:
                collect = 1;
                break;
            case 2:
                collect = 2;
                break;
            case 3:
                collect = 3;
                break;
            case 4:
                collect = 4;
                break;
            case 5:
                collect = 5;
                break;
            case 6:
                collect = 6;
                break;
            case 7:
                collect = 7;
                break;
            case 8:
                collect = 8;
                break;
            case 9:
                collect = 9;
                break;
            case 10:
                collect = 10;
                break;
            case 11:
                collect = 11;
                break;
            case 12:
                collect = 12;
                break;
            case 13:
                collect = 13;
                break;
            case 14:
                collect = 14;
                break;
            case 15:
                collect = 15;
                break;
            default:
                break;
        }
        pos = scrollRect.verticalNormalizedPosition;

        SceneManager.LoadScene("collecttellScene");
    }

    public static int getCollect()
    {
        return collect;
    }

    public static float getPos()
    {
        return pos;
    }
}
