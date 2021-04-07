using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvupSceneController : MonoBehaviour
{
    GameObject text_bananalevel;
	GameObject text_applelevel;
	GameObject text_pineapplelevel;
	GameObject text_moneybanana;
	GameObject text_moneyapple;
	GameObject text_moneypineapple;
	GameObject text_money;
    GameObject text_bananalevelMax;
    GameObject text_applelevelMax;
    GameObject text_pineapplelevelMax;
    GameObject buttonbanana;
    GameObject buttonapple;
    GameObject buttonpineapple;
    GameObject Maxbuttonbanana;
    GameObject Maxbuttonapple;
    GameObject Maxbuttonpineapple;
    GameObject text_moneybananaMax;
    GameObject text_moneyappleMax;
    GameObject text_moneypineappleMax;
    GameObject buttonblock;
    GameObject bananabuttonNodeMax;
    GameObject applebuttonNodeMax;
    GameObject pineapplebuttonNodeMax;
    GameObject text_block;
    GameObject stareffect;
    ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();

    int bananaLevel, appleLevel, pineappleLevel;
	int coin, block;

	// Start is called before the first frame update
	void Start()
    {
		this.bananaLevel = PlayerPrefs.GetInt("bananaLevel", 1);
		this.text_bananalevel = GameObject.Find("text_bananalevel");
        this.text_moneybanana = GameObject.Find("text_moneybanana");
        this.buttonbanana = GameObject.Find("buttonbanana");
        this.bananabuttonNodeMax = GameObject.Find("bananabuttonNodeMax");
        if (bananaLevel>=5)
        {
            this.text_bananalevel.GetComponent<Text>().text = "Lv : MAX";
            this.text_moneybanana.GetComponent<Text>().text = "-----";
            buttonbanana.SetActive(false);
        }
        else
        {
            this.text_bananalevel.GetComponent<Text>().text = "Lv : " + bananaLevel;
            this.text_moneybanana.GetComponent<Text>().text = "" + bananaLevel * 20;
            bananabuttonNodeMax.SetActive(false);
        }


		this.appleLevel = PlayerPrefs.GetInt("appleLevel", 1);
		this.text_applelevel = GameObject.Find("text_applelevel");
        this.text_moneyapple = GameObject.Find("text_moneyapple");
        this.buttonapple = GameObject.Find("buttonapple");
        this.applebuttonNodeMax = GameObject.Find("applebuttonNodeMax");
        if (appleLevel >= 5)
        {
            this.text_applelevel.GetComponent<Text>().text = "Lv : MAX";
            this.text_moneyapple.GetComponent<Text>().text = "-----";
            buttonapple.SetActive(false);
        }
        else
        {
            this.text_applelevel.GetComponent<Text>().text = "Lv : " + appleLevel;
            this.text_moneyapple.GetComponent<Text>().text = "" + appleLevel * 20;
            applebuttonNodeMax.SetActive(false);
        }

		this.pineappleLevel = PlayerPrefs.GetInt("pineappleLevel", 1);
		this.text_pineapplelevel = GameObject.Find("text_pineapplelevel");
        this.text_moneypineapple = GameObject.Find("text_moneypineapple");
        this.buttonpineapple = GameObject.Find("buttonpineapple");
        this.pineapplebuttonNodeMax = GameObject.Find("pineapplebuttonNodeMax");
        if (pineappleLevel >= 5)
        {
            this.text_pineapplelevel.GetComponent<Text>().text = "Lv : MAX";
            this.text_moneypineapple.GetComponent<Text>().text = "-----";
            buttonpineapple.SetActive(false);
        }
        else
        {
            this.text_pineapplelevel.GetComponent<Text>().text = "Lv : " + pineappleLevel;
            this.text_moneypineapple.GetComponent<Text>().text = "" + pineappleLevel * 20;
            pineapplebuttonNodeMax.SetActive(false);
        }

        this.text_bananalevelMax = GameObject.Find("text_bananalevelMax");
        this.Maxbuttonbanana = GameObject.Find("Maxbuttonbanana");
        this.text_moneybananaMax = GameObject.Find("text_moneybananaMax");
        if(bananaLevel==6)
        {
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_bananalevelMax.GetComponent<Text>().text = "限界突破しました！";
            }
            else
            {
                this.text_bananalevelMax.GetComponent<Text>().fontSize = 25;
                this.text_bananalevelMax.GetComponent<Text>().text = "Banana has overcame the limit！";
            }
            this.text_moneybananaMax.GetComponent<Text>().text = "-----";
            Maxbuttonbanana.SetActive(false);
        }
        this.text_applelevelMax = GameObject.Find("text_applelevelMax");
        this.Maxbuttonapple = GameObject.Find("Maxbuttonapple");
        this.text_moneyappleMax = GameObject.Find("text_moneyappleMax");
        if (appleLevel == 6)
        {
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_applelevelMax.GetComponent<Text>().text = "限界突破しました！";
            }
            else
            {
                this.text_applelevelMax.GetComponent<Text>().fontSize = 25;
                this.text_applelevelMax.GetComponent<Text>().text = "Apple has overcame the limit！";
            }
            this.text_moneyappleMax.GetComponent<Text>().text = "-----";
            Maxbuttonapple.SetActive(false);
        }
        this.text_pineapplelevelMax = GameObject.Find("text_pineapplelevelMax");
        this.Maxbuttonpineapple = GameObject.Find("Maxbuttonpineapple");
        this.text_moneypineappleMax = GameObject.Find("text_moneypineappleMax");
        if (pineappleLevel == 6)
        {
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_pineapplelevelMax.GetComponent<Text>().text = "限界突破しました！";
            }
            else
            {
                this.text_pineapplelevelMax.GetComponent<Text>().fontSize = 25;
                this.text_pineapplelevelMax.GetComponent<Text>().text = "Pineapple has overcame the limit！";
            }
            this.text_moneypineappleMax.GetComponent<Text>().text = "-----";
            Maxbuttonpineapple.SetActive(false);
        }

        this.block = PlayerPrefs.GetInt("block", 0);
        this.text_block = GameObject.Find("text_block");
        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            this.text_block.GetComponent<Text>().text = "所持数：" + block;
        }
        else
        {
            this.text_block.GetComponent<Text>().text = "Shield：" + block;
        }
        this.buttonblock = GameObject.Find("buttonblock");
        this.coin = PlayerPrefs.GetInt("coin", 0);
		this.text_money = GameObject.Find("text_money");
		this.text_money.GetComponent<Text>().text = ""+coin;

        this.stareffect = GameObject.Find("stareffect");
        emitParams.applyShapeToPosition = true;
        emitParams.position = new Vector3(emitParams.position.x, emitParams.position.y+1000, emitParams.position.z+1000 );//なぜだか分からないが最初のエフェクトは拡散しないで汚いのでこ２行でに見えないところで飛ばす
        stareffect.GetComponent<ParticleSystem>().Emit(emitParams, 1);
    }


    // Update is called once per frame
    void Update()
    {

    }


	public void bananalvup()
	{
        if (bananaLevel<5 && coin>=bananaLevel*20)
		{
            emitParams.position = buttonbanana.transform.position;
            emitParams.position = new Vector3(emitParams.position.x - 45, emitParams.position.y, emitParams.position.z - 50);
            stareffect.GetComponent<ParticleSystem>().Emit(emitParams, 30);
            coin -= bananaLevel * 20;
			bananaLevel += 1;
			PlayerPrefs.SetInt("coin", coin);
			PlayerPrefs.SetInt("bananaLevel",bananaLevel);
            if (bananaLevel >= 5)
            {
                this.text_moneybanana.GetComponent<Text>().text = "-----";
                this.text_bananalevel.GetComponent<Text>().text = "Lv : MAX";
                buttonbanana.SetActive(false);
            }
            else
            {
                this.text_moneybanana.GetComponent<Text>().text = "" + bananaLevel * 20;
                this.text_bananalevel.GetComponent<Text>().text = "Lv : " + bananaLevel;
            }
            this.text_money.GetComponent<Text>().text = "" + coin;
		}
        else if(bananaLevel>=5)
        {
            this.text_bananalevel.GetComponent<Text>().fontSize = 40;
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_bananalevel.GetComponent<Text>().text = "最大レベルです！";
            }
            else
            {
                this.text_bananalevel.GetComponent<Text>().text = "Banana's level is max！";
            }       
        }
		else　
		{
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_bananalevel.GetComponent<Text>().fontSize = 40;
                this.text_bananalevel.GetComponent<Text>().text = "コインが足りません！";
            }
            else
            {
                this.text_bananalevel.GetComponent<Text>().fontSize = 30;
                this.text_bananalevel.GetComponent<Text>().text = "You don't have enough coins.";
            }
		}
		PlayerPrefs.Save();
	}


	public void applelvup()
	{
        
        if (appleLevel < 5 && coin >= appleLevel * 20)
		{
            emitParams.position = buttonapple.transform.position;
            emitParams.position = new Vector3(emitParams.position.x - 45, emitParams.position.y, emitParams.position.z - 50);
            stareffect.GetComponent<ParticleSystem>().Emit(emitParams, 30);
            coin -= appleLevel * 20;
			appleLevel += 1;
			PlayerPrefs.SetInt("coin", coin);
			PlayerPrefs.SetInt("appleLevel", appleLevel);
            if (appleLevel >= 5)
            {
                this.text_moneyapple.GetComponent<Text>().text = "-----";
                this.text_applelevel.GetComponent<Text>().text = "Lv : MAX";
                buttonapple.SetActive(false);
            }
            else
            {
                this.text_moneyapple.GetComponent<Text>().text = "" + appleLevel * 20;
                this.text_applelevel.GetComponent<Text>().text = "Lv : " + appleLevel;
            }
            this.text_money.GetComponent<Text>().text = "" + coin;
		}
        else if(appleLevel>=5)
        {
            this.text_applelevel.GetComponent<Text>().fontSize = 40;
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_applelevel.GetComponent<Text>().text = "最大レベルです！";
            }
            else
            {
                this.text_applelevel.GetComponent<Text>().text = "Apple's level is max！";
            }
        }
		else
		{
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_applelevel.GetComponent<Text>().fontSize = 40;
                this.text_applelevel.GetComponent<Text>().text = "コインが足りません！";
            }
            else
            {
                this.text_applelevel.GetComponent<Text>().fontSize = 30;
                this.text_applelevel.GetComponent<Text>().text = "You don't have enough coins.";
            }
		}
		PlayerPrefs.Save();
	}

	public void pineapplelvup()
	{
		if (pineappleLevel < 5 && coin >= pineappleLevel * 20)
		{
            emitParams.position = buttonpineapple.transform.position;
            emitParams.position = new Vector3(emitParams.position.x - 45, emitParams.position.y, emitParams.position.z - 50);
            Debug.Log("ok");
            stareffect.GetComponent<ParticleSystem>().Emit(emitParams, 30);
            coin -= pineappleLevel * 20;
			pineappleLevel += 1;
			PlayerPrefs.SetInt("coin", coin);
			PlayerPrefs.SetInt("pineappleLevel", pineappleLevel);	
            if (pineappleLevel >= 5)
            {
                this.text_moneypineapple.GetComponent<Text>().text = "-----";
                this.text_pineapplelevel.GetComponent<Text>().text = "Lv : MAX";
                buttonpineapple.SetActive(false);
            }
            else
            {
                this.text_moneypineapple.GetComponent<Text>().text = "" + pineappleLevel * 20;
                this.text_pineapplelevel.GetComponent<Text>().text = "Lv : " + pineappleLevel;
            }
            this.text_money.GetComponent<Text>().text = "" + coin;
		}
        else if(pineappleLevel>=5)
        {
            this.text_pineapplelevel.GetComponent<Text>().fontSize = 40;
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_pineapplelevel.GetComponent<Text>().text = "最大レベルです！";
            }
            else
            {
                this.text_pineapplelevel.GetComponent<Text>().text = "Pineapple's level is max！";
            }       
        }
		else
		{
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_pineapplelevel.GetComponent<Text>().fontSize = 40;
                this.text_pineapplelevel.GetComponent<Text>().text = "コインが足りません！";
            }
            else
            {
                this.text_pineapplelevel.GetComponent<Text>().fontSize = 30;
                this.text_pineapplelevel.GetComponent<Text>().text = "You don't have enough coins.";
            }
		}
		PlayerPrefs.Save();
	}

    public void bananaMax()
    {
        if (coin >= 200&&bananaLevel==5)
        {
            emitParams.position = Maxbuttonbanana.transform.position;
            emitParams.position = new Vector3(emitParams.position.x - 45, emitParams.position.y, emitParams.position.z - 50);
            stareffect.GetComponent<ParticleSystem>().Emit(emitParams, 30);
            coin -= 200;
            bananaLevel += 1;
            PlayerPrefs.SetInt("coin", coin);
            PlayerPrefs.SetInt("bananaLevel", bananaLevel);
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_bananalevelMax.GetComponent<Text>().text = "限界突破しました！";
            }
            else
            {
                this.text_bananalevelMax.GetComponent<Text>().fontSize = 25;
                this.text_bananalevelMax.GetComponent<Text>().text = "Banana has overcame the limit！";
            }   
            this.text_moneybananaMax.GetComponent<Text>().text = "-----";
            this.text_money.GetComponent<Text>().text = "" + coin;
            Maxbuttonbanana.SetActive(false);
        }
        else if(bananaLevel>5)
        {
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_bananalevelMax.GetComponent<Text>().text = "限界突破しました！";
            }
            else
            {
                this.text_bananalevelMax.GetComponent<Text>().fontSize = 25;
                this.text_bananalevelMax.GetComponent<Text>().text = "Banana has overcame the limit！";
            }
                
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_bananalevelMax.GetComponent<Text>().fontSize = 40;
                this.text_bananalevelMax.GetComponent<Text>().text = "コインが足りません。";
            }
            else
            {
                this.text_bananalevelMax.GetComponent<Text>().fontSize = 30;
                this.text_bananalevelMax.GetComponent<Text>().text = "You don't have enough coins.";
            }
                
        }
        PlayerPrefs.Save();
    }

    public void appleMax()
    {
        if (coin >= 200&&appleLevel==5)
        {
            emitParams.position = Maxbuttonapple.transform.position;
            emitParams.position = new Vector3(emitParams.position.x - 45, emitParams.position.y, emitParams.position.z - 50);
            stareffect.GetComponent<ParticleSystem>().Emit(emitParams, 30);
            coin -= 200;
            appleLevel += 1;
            PlayerPrefs.SetInt("coin", coin);
            PlayerPrefs.SetInt("appleLevel", appleLevel);
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_applelevelMax.GetComponent<Text>().text = "限界突破しました！";
            }
            else
            {
                this.text_applelevelMax.GetComponent<Text>().fontSize = 25;
                this.text_applelevelMax.GetComponent<Text>().text = "Apple has overcame the limit！";
            }   
            this.text_moneyappleMax.GetComponent<Text>().text = "-----";
            this.text_money.GetComponent<Text>().text = "" + coin;
            Maxbuttonapple.SetActive(false);
        }
        else if(appleLevel>5)
        {
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_applelevelMax.GetComponent<Text>().text = "限界突破しました！";
            }
            else
            {
                this.text_applelevelMax.GetComponent<Text>().fontSize = 25;
                this.text_applelevelMax.GetComponent<Text>().text = "Apple has overcame the limit！";
            }        
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_applelevelMax.GetComponent<Text>().fontSize = 40;
                this.text_applelevelMax.GetComponent<Text>().text = "コインが足りません。";
            }
            else
            {
                this.text_applelevelMax.GetComponent<Text>().fontSize = 30;
                this.text_applelevelMax.GetComponent<Text>().text = "You don't have enough coins.";
            }
                
        }
        PlayerPrefs.Save();
    }

    public void pineappleMax()
    {
        if (coin >= 200&&pineappleLevel==5)
        {
            emitParams.position = Maxbuttonpineapple.transform.position;
            emitParams.position = new Vector3(emitParams.position.x - 45, emitParams.position.y, emitParams.position.z - 50);
            stareffect.GetComponent<ParticleSystem>().Emit(emitParams, 30);
            coin -= 200;
            pineappleLevel += 1;
            PlayerPrefs.SetInt("coin", coin);
            PlayerPrefs.SetInt("pineappleLevel", pineappleLevel);
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_pineapplelevelMax.GetComponent<Text>().text = "限界突破しました！";
            }
            else
            {
                this.text_pineapplelevelMax.GetComponent<Text>().fontSize = 25;
                this.text_pineapplelevelMax.GetComponent<Text>().text = "Pineapple has overcame the limit！";
            }
            this.text_moneypineappleMax.GetComponent<Text>().text = "-----";
            this.text_money.GetComponent<Text>().text = "" + coin;
            Maxbuttonpineapple.SetActive(false);
        }
        else if(pineappleLevel>5)
        {
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_pineapplelevelMax.GetComponent<Text>().text = "限界突破しました！";
            }
            else
            {
                this.text_pineapplelevelMax.GetComponent<Text>().fontSize = 25;
                this.text_pineapplelevelMax.GetComponent<Text>().text = "Pineapple has overcame the limit！";
            }
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_pineapplelevelMax.GetComponent<Text>().fontSize = 40;
                this.text_pineapplelevelMax.GetComponent<Text>().text = "コインが足りません。";
            }
            else
            {
                this.text_pineapplelevelMax.GetComponent<Text>().fontSize = 30;
                this.text_pineapplelevelMax.GetComponent<Text>().text = "You don't have enough coins.";
            }
        }
        PlayerPrefs.Save();
    }

    public void blockget()
    {
        if(coin>=5)
        {
            emitParams.position = buttonblock.transform.position;
            emitParams.position = new Vector3(emitParams.position.x - 45, emitParams.position.y, emitParams.position.z - 50);
            stareffect.GetComponent<ParticleSystem>().Emit(emitParams, 30);
            coin -= 5;
            block += 1;
            PlayerPrefs.SetInt("coin", coin);
            PlayerPrefs.SetInt("block", block);
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_block.GetComponent<Text>().text = "所持数：" + block;
            }
            else
            {
                this.text_block.GetComponent<Text>().text = "Shield：" + block;
            }
            this.text_money.GetComponent<Text>().text = "" + coin;
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                this.text_block.GetComponent<Text>().fontSize = 40;
                this.text_block.GetComponent<Text>().text = "コインが足りません。";
            }
            else
            {
                this.text_block.GetComponent<Text>().fontSize = 30;
                this.text_block.GetComponent<Text>().text = "You don't have enough coins.";
            }
        }
        PlayerPrefs.Save();
    }

    public void getcoin()//テストプレイ用
    {
        coin += 1000;
        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.Save();
    }
}
