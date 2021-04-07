using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collecttellSceneController : MonoBehaviour
{
	int i=0;
	int collect = 0;
	GameObject[] collectionArray = new GameObject[15];
	GameObject text_setsumei;
	// Start is called before the first frame update
	void Start()
	{
		for (i = 0; i < 15; i++)
		{
			this.collectionArray[i] = GameObject.Find("collection" + (i + 1));
			collectionArray[i].SetActive(false);
		}
        collect= collectSceneController.getCollect();
		collectionArray[collect - 1].SetActive(true);

		this.text_setsumei = GameObject.Find("text_setsumei");
		this.text_setsumei.GetComponent<Text>().text = "";

        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            switch (collect)
            {
                case 1:
                    this.text_setsumei.GetComponent<Text>().text = "【タイヤ】\n★\nタイヤは車輪の円環部分。19世紀に空気入りタイヤ、20世紀半ばにはチューブレスタイヤ、90年代にはスタッドレスタイヤなどの様々なタイヤが登場し、自動車の発達ととに進化を続けている。";
                    break;
                case 2:
                    this.text_setsumei.GetComponent<Text>().text = "【サイドミラー】\n★★\n車両の前席ドア外側にあり運転手が側方後方の確認に使用する。バックミラーも用いると広範囲を見ることができるが、それでも死角は多いため安全確認や合図などを怠らないように。";
                    break;
                case 3:
                    this.text_setsumei.GetComponent<Text>().text = "【バッテリー】\n★\nエンジンを始動したり、ランプやエアコンを使用するのに必要。オルタネーターという発電機で絶えず充電しており、放電と充電ができる二次電池である。";
                    break;
                case 4:
                    this.text_setsumei.GetComponent<Text>().text = "【ハンドル】\n★★\n進行方向を変えるためのもの。車輪と道路の摩擦でハンドルを回すのには本来大きな力が必要だが、油圧や電気モーターによりハンドルを軽くする「パワーステアリング」がほぼ全ての車に装備されている。";
                    break;
                case 5:
                    this.text_setsumei.GetComponent<Text>().text = "【カーナビ】\n★★\n自動車の走行時に目的地までの経路案内を行う電子機器。渋滞情報や駐車場の空き情報などを提供するものもある。ただし運転中の注視や操作はとても危険！";
                    break;
                case 6:
                    this.text_setsumei.GetComponent<Text>().text = "【ナンバープレート】\n★★★\nナンバープレートは車両が正式に登録され保安基準に適合していることを示す役割がある。ちなみに「お」「し」「へ」「ん」は使用されていない。";
                    break;
                case 7:
                    this.text_setsumei.GetComponent<Text>().text = "【スピードメーター】\n★★\n速度を計測し表示する。タイヤ（正確にはトランスミッション）の回転数から計算しているため、摩擦や空気圧などによりタイヤの外周が変化するとそれが誤差の要因になってしまう。";
                    break;
                case 8:
                    this.text_setsumei.GetComponent<Text>().text = "【ドライブレコーダー】\n★★★\n映像・音声を記録することができる自動車用の装置。事故が起きた際の証拠として提出することができ、事後処理がスムーズになることがある。最近だと前方だけでなく後方を撮影できるタイプもある。";
                    break;
                case 9:
                    this.text_setsumei.GetComponent<Text>().text = "【スマートフォン】\n★★★\n近年「ながらスマホ」による交通事故が増加している。カーナビの機能をもつアプリなどもあるが、運転中にスマホを見ると注意力が大幅に失われ重大な事故に直結することがあるため「ながらスマホ」は絶対にやってはいけない。";
                    break;
                case 10:
                    this.text_setsumei.GetComponent<Text>().text = "【お酒】\n★★★★\n体内にアルコールが入ると動体視力や判断力、平衡感覚が落ち重大な事故に直結するため飲酒運転は絶対にやってはいけない。個人差はあるがビール１缶のアルコールを分解するのにかかる時間は約４時間でと言われている。";
                    break;
                case 11:
                    this.text_setsumei.GetComponent<Text>().text = "【信号機】\n★★★★★\n道路における交通の安全や流れの確保のために指示の信号を示すもの。日本では自動車用の信号機は一般的に横型であるが、積雪の多い地域では縦型の信号機が設置されることがある。";
                    break;
                case 12:
                    this.text_setsumei.GetComponent<Text>().text = "【自転車】\n★★★★\n自転車は気軽に乗ることができとても便利な乗り物である。しかし、「ながら運転」をしていて自動車や歩行者などに気づかず接触したり、車体が小さいために自動車の死角に入り巻き込事故が起こったりと危険も多い。";
                    break;
                case 13:
                    this.text_setsumei.GetComponent<Text>().text = "【自動運転】\n★★★★★\n人間が操作しなくても車が自動で運転してくれること。日本では2020年から高速道路などの限定的な環境での自動運転（自動運転レベル３）が実現されるだろう。しかし、事故責任や精度など課題も多い。";
                    break;
                case 14:
                    this.text_setsumei.GetComponent<Text>().text = "【思いやり】\n★★★★★★\n事故を起こさないために運転技術を身につけ交通規則を守ることも大事だが、一番は相手が安全に行動できるようにする「思いやり」ではないだろか。相手を思いやることで、運転に余裕ができ的確で安全な運転ができるだろう。";
                    break;
                case 15:
                    this.text_setsumei.GetComponent<Text>().text = "【タピのみ】\n★★★★★★\n2019年、一部の若者に大流行したアプリ「タピのみ」。タップしてタピオカを飲んだり、ガチャを回してタピオカを集めたり、ストローから出てくるタピオカをつぶしたり、とハマった人も多いだろう。";
                    break;
                default:
                    break;
            }
        }
        else//以下は英語版
        {
            switch (collect)
            {
                case 1:
                    this.text_setsumei.GetComponent<Text>().text = "【Tire】\n★\nTire is the ring of the wheel. Various types of tires, such as pneumatic tires in the 19th century, tubeless tires in the mid-20th century, and studless tires in the 1990s, have continued to be convinient with the development of automobiles.";
                    break;
                case 2:
                    this.text_setsumei.GetComponent<Text>().text = "【Side view mirror】\n★★\nIt is located outside the front seat door of the vehicle and is used by the driver to check the side rear. When you see a rear-view mirror and side-view mirror, you can see a wide area, but there are still blind spots. So, don't forget safety checks.";
                    break;
                case 3:
                    this.text_setsumei.GetComponent<Text>().text = "【Battery】\n★\nYou need a battery for starting the engine and turning on lamps and air conditioners. It is a secondary battery and constantly charged by an alternator. It can be discharged and charged.";
                    break;
                case 4:
                    this.text_setsumei.GetComponent<Text>().text = "【Steering wheel】\n★★\nSteering wheel is to change a car around. Essentially, turning it requires a lot of power due to friction between the wheels and road. But, many cars are equipped with power steering, which uses a hydraulic or electric motor to change a car around easily.";
                    break;
                case 5:
                    this.text_setsumei.GetComponent<Text>().text = "【Car navigation system】\n★★\nCar navigetaion system is an electronic device that provides route guidance to a destination while driving. Some provide traffic congestion and parking lot availability information. But, watching and operating while driving is dangerous!";
                    break;
                case 6:
                    this.text_setsumei.GetComponent<Text>().text = "【Number plate / License plate】\n★★★\nThe license plate serves to indicate that the vehicle is officially registered and meets security standards. In Japan, hiragana characters are used in addition to numbers and place names, but \"お\", \"へ\", \"し\", and \"ん\" are not used.";
                    break;
                case 7:
                    this.text_setsumei.GetComponent<Text>().text = "【Speedometer】\n★★\nSpeedometer measure and display speed. Since the calculation is based on the rotation speed of the tire (more precisely, the transmission), a change in the outer circumference of the tire due to friction and air pressure, causes an error.";
                    break;
                case 8:
                    this.text_setsumei.GetComponent<Text>().text = "【Dash cam】\n★★★\nDash cam is an automotive device that can record video and audio. It can be submitted as evidence when an accident has occurred. Recently, some types can shoot not only the front but also the back.";
                    break;
                case 9:
                    this.text_setsumei.GetComponent<Text>().text = "【Smartphone】\n★★★\nRecentury, traffic accidents caused by uisng smartphones while driving have been increasing. Some apps in smartphone can navigate while driving, but when you look at your smartphone while driving, you are less careful about driving.";
                    break;
                case 10:
                    this.text_setsumei.GetComponent<Text>().text = "【Alocoholic beverage】\n★★★★\nDon't drink alcohol while driving. when you drink alcohol, it will weaken your visual acuity, your judgment and your sense of balance, and leads to serious accidents. It is said that it takes about 4 hours to decompose the alcohol of a can of beer.";
                    break;
                case 11:
                    this.text_setsumei.GetComponent<Text>().text = "【Traffic light】\n★★★★★\nTraffic light is a signal indicating an instruction to ensure traffic safety and flow on the road. In Japan, traffic signals for automobiles are generally horizontal, but in areas with heavy snowfall, vertical traffic signals may be installed.";
                    break;
                case 12:
                    this.text_setsumei.GetComponent<Text>().text = "【Bycycle】\n★★★★\nBicycles are easy to ride and very convenient. However, it is dangerous to use a smartphone and an earphone while driving because you can strike a car without noticing.";
                    break;
                case 13:
                    this.text_setsumei.GetComponent<Text>().text = "【Autonomous car】\n★★★★★\nThe car will automatically drive without human intervention. In Japan, autonomous driving in limited environments such as expressways will be realized in 2020. But, there are many issues such as accident responsibility and accuracy of driving.";
                    break;
                case 14:
                    this.text_setsumei.GetComponent<Text>().text = "【Consideration】\n★★★★★★\nTure, it is important to acquire driving skills and obey traffic rules in order to prevent accidents. However, it is the most important to be considerate and give way to other cars. By doing so, you will get room in your mind and be able to drive accurately and safely.";
                    break;
                case 15:
                    this.text_setsumei.GetComponent<Text>().text = "【Tapinomi】\n★★★★★★\nIn 2019, the app Tapinomi gained popularity with some young people. They will be addicted to tapping and drinking bubble tea, buy loot boxs to collect bubble tea, or crushing bubble tea in straw.";
                    break;
                default:
                    break;
            }
        }
        
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonUp(0))
		{
			SceneManager.LoadScene("collectionScene");
		}
	}
}
