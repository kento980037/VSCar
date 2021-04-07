using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hintSceneController : MonoBehaviour
{
    int stage_ = 1;
    int i = 0;//ヒントで何を表示するかのランダム変数
    float time = 0;
    float rot = 0;
    public Material sky1;
    public Material sky2;
    public Material sky3;
    public Material sky4;
    public Material sky5;
    public Material sky6;
    GameObject load_image;
    GameObject Text_hint;
    GameObject AoriCar;

    // Start is called before the first frame update
    void Start()
    {
        stage_ = GameSelectController.getStage();
        if (stage_ == 1)
        {
            RenderSettings.skybox = sky1;
            i = Random.Range(0, 7);
        }
        else if (stage_ == 2)
        {
            RenderSettings.skybox = sky2;
            i = Random.Range(0, 8);
        }
        else if (stage_ == 3)
        {
            RenderSettings.skybox = sky3;
            i = Random.Range(0, 9);
        }
        else if (stage_ == 4)
        {
            RenderSettings.skybox = sky4;
            i = Random.Range(0, 10);
        }
        else if (stage_ == 5)
        {
            RenderSettings.skybox = sky5;
            i = Random.Range(0, 11);
        }
        else if (stage_ == 6)
        {
            RenderSettings.skybox = sky6;
            i = Random.Range(0, 11);
        }

        this.load_image = GameObject.Find("load_image");
        this.Text_hint = GameObject.Find("Text_hint");
        this.AoriCar = GameObject.Find("AoriCar");

        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            switch (i)
            {
                case 0:
                    this.Text_hint.GetComponent<Text>().text = "ヒント\n\nくだものはレベルアップすると、相手に与えられるダメージがアップ。なかなかクリアできないときはレベルアップしてみよう！";
                    break;
                case 1:
                    this.Text_hint.GetComponent<Text>().text = "ヒント\n\nバナナは相手に当たるとダメージを与えるほかに、相手との距離を離します。車間距離が近いときはバナナを投げてみよう！";
                    break;
                case 2:
                    this.Text_hint.GetComponent<Text>().text = "ヒント\n\nリンゴは相手に当たるとダメージを与えるほかに、自分のイライラを回復します。自分のイライラが限界のときはリンゴを投げてみよう！";
                    break;
                case 3:
                    this.Text_hint.GetComponent<Text>().text = "ヒント\n\nパイナップルは相手に当たると大ダメージを与えられる。相手のダメージが減りづらいときはパイナップルを投げてみよう！";
                    break;
                case 4:
                    this.Text_hint.GetComponent<Text>().text = "ヒント\n\nくだものは最大までレベルアップすると限界突破することができるらしい。限界突破すると特殊な能力を獲得できるのかもしれない・・・";
                    break;
                case 5:
                    this.Text_hint.GetComponent<Text>().text = "ヒント\n\nメニュー画面の「こうこく」をタップすると動画広告を見ることができ、何秒か再生するとコインを獲得できるぞ。";
                    break;
                case 6:
                    this.Text_hint.GetComponent<Text>().text = "ヒント\n\nシールドは一瞬相手の攻撃を避けることができるぞ。イライラが限界のときは積極的に使っていこう。ただし１度使うとなくなってしまうから注意。";
                    break;
                case 7:
                    this.Text_hint.GetComponent<Text>().text = "ヒント\n\n相手が放つクラクションはイライラしやすいので注意だ。イライラが限界のときはシールドでガードしよう。";
                    break;
                case 8:
                    this.Text_hint.GetComponent<Text>().text = "ヒント\n\n相手が放つ空き缶はイライラするだけでなく、しばらくの間全てのくだものが使えなくなってしまうので注意が必要だ。";
                    break;
                case 9:
                    this.Text_hint.GetComponent<Text>().text = "ヒント\n\n相手の放つライトはそこまでイライラしないが、視界が妨げられるので注意が必要だ！";
                    break;
                case 10:
                    this.Text_hint.GetComponent<Text>().text = "ヒント\n\n相手が使つ銃弾に当たるとかなりイライラするので注意。銃をかまえてからおよそ1秒後に撃ってくるぞ！";
                    break;
                default:
                    break;
            }
        }
        else//以下は英語版
        {
            switch (i)
            {
                case 0:
                    this.Text_hint.GetComponent<Text>().text = "Hint\n\nAs the level of the fruit increases, the damage to the car increases. When you can't clear the stage, try to level up!";
                    break;
                case 1:
                    this.Text_hint.GetComponent<Text>().text = "Hint\n\nBananas will not only cause damage to the car when hitting it, but will also increase their distance from the car. Throw bananas when the distance is short!";
                    break;
                case 2:
                    this.Text_hint.GetComponent<Text>().text = "Hint\n\nThe apple will not only cause damage to the car when hitting it, but will also relieve your frustration. Throw an apple when your irritability is at its limit!";
                    break;
                case 3:
                    this.Text_hint.GetComponent<Text>().text = "Hint\n\nPineapples can cause a lot of damage to the car when hitting it. If it is difficult to cause damage to the car, throw a pineapple!";
                    break;
                case 4:
                    this.Text_hint.GetComponent<Text>().text = "Hint\n\nFruit seems to be able to overcome its limit when leveled up to the maximum. If you overcome the limits, you may be able to acquire special abilities ...";
                    break;
                case 5:
                    this.Text_hint.GetComponent<Text>().text = "Hint\n\nTap Kokokoku on the menu screen to watch video ads and play for a few seconds, and get 30 coins.";
                    break;
                case 6:
                    this.Text_hint.GetComponent<Text>().text = "Hint\n\nThe shield can avoid the car's attack for a moment. When frustration is the limit, let's use it. However, note that it will disappear once you use it.";
                    break;
                case 7:
                    this.Text_hint.GetComponent<Text>().text = "Hint\n\nWatch out for the klaxon the car emits, which can be frustrating. When frustration is at its limits, guard with a shield.";
                    break;
                case 8:
                    this.Text_hint.GetComponent<Text>().text = "Hint\n\nBe careful the empty cans the car releases! It will not only be frustrating, but will also make all the fruit unusable for a while.";
                    break;
                case 9:
                    this.Text_hint.GetComponent<Text>().text = "Hint\n\nThe car's light will not only be frustrating you, but also obstruct your view.";
                    break;
                case 10:
                    this.Text_hint.GetComponent<Text>().text = "Hint\n\nBe careful bullets the car shoots. It can be quite frustrating you when hitting. The car shoot a bullet about a second after holding the gun!";
                    break;
                default:
                    break;
            }
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;

        if(time>4.0f)
        {
            load_image.SetActive(false);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-1);
            this.AoriCar.transform.position= new Vector3(transform.position.x+3, this.AoriCar.transform.position.y, transform.position.z + 30);
        }
        if(time>6.4f)
        {
            rot += 0.8f;
            transform.Rotate(new Vector3(0, 0.8f, 0));
        }
        if(rot>=178)
        {
            if (stage_ == 1)
            {
                SceneManager.LoadSceneAsync("GameScene1");
            }
            else if (stage_ == 2)
            {
                SceneManager.LoadSceneAsync("GameScene2");
            }
            else if (stage_ == 3)
            {
                SceneManager.LoadSceneAsync("GameScene3");
            }
            else if (stage_ == 4)
            {
                SceneManager.LoadSceneAsync("GameScene4");
            }
            else if (stage_ == 5)
            {
                SceneManager.LoadSceneAsync("GameScene5");
            }
            else if (stage_ == 6)
            {
                SceneManager.LoadSceneAsync("GameScene6");
            }
        }
    }
}
