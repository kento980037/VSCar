using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canController : MonoBehaviour
{
	GameObject camera1;
	GameObject PlayerhpGauge;
    GameObject banana_Buttom;
    GameObject apple_Buttom;
    GameObject pineapple_Buttom;
    GameObject rockButton;

    // Start is called before the first frame update
    void Start()
    {
		this.camera1 = GameObject.Find("Main Camera");
		this.PlayerhpGauge = GameObject.Find("PlayerhpGauge");
        this.banana_Buttom = GameObject.Find("bananaButtom");
        this.apple_Buttom = GameObject.Find("appleButtom");
        this.pineapple_Buttom = GameObject.Find("pineappleButtom");
        this.rockButton = GameObject.Find("rockButtom");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		Vector3 pos = transform.position;
		pos.z -= 1.3f;
		transform.position = pos;
		//transform.position.z = transform.position.z - 1.4f;
		Vector3 p1 = transform.position;
		Vector3 p2 = this.camera1.transform.position;
		Vector3 dir = p1 - p2;
		float d = dir.magnitude;
		if (d < 3.0f)
		{
			Destroy(gameObject);
            if (this.rockButton.GetComponent<Image>().fillAmount <= 0.001f || this.rockButton.GetComponent<Image>().fillAmount >= 0.999f)
            {
                this.PlayerhpGauge.GetComponent<Image>().fillAmount -= 0.24f;
                this.banana_Buttom.GetComponent<Image>().fillAmount = 0;
                this.apple_Buttom.GetComponent<Image>().fillAmount = 0;
                this.pineapple_Buttom.GetComponent<Image>().fillAmount = 0;
            }
                
        }

		else if (d > 250 && d < 1000)
		{
			Destroy(gameObject);
		}
		else if (d >= 1000)
		{
			transform.position = new Vector3(this.camera1.transform.position.x, this.camera1.transform.position.y, this.camera1.transform.position.z + 1200);
		}
	}
}
