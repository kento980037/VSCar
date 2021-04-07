using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class klaxonController : MonoBehaviour
{
	GameObject camera1;
	GameObject PlayerhpGauge;
    GameObject rockButton;

	// Start is called before the first frame update
	void Start()
    {
		this.camera1 = GameObject.Find("Main Camera");
		this.PlayerhpGauge = GameObject.Find("PlayerhpGauge");
        this.rockButton = GameObject.Find("rockButtom");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
		Vector3 p1 = transform.position;
		Vector3 p2 = this.camera1.transform.position;
		Vector3 dir = p1 - p2;
		float d = dir.magnitude;
		if (d < 3.5f)
		{
            if (this.rockButton.GetComponent<Image>().fillAmount <= 0.001f || this.rockButton.GetComponent<Image>().fillAmount >= 0.999f)
            {
                this.PlayerhpGauge.GetComponent<Image>().fillAmount -= 0.12f;
            }
			Destroy(gameObject);
		}
		else if (d > 250 && d < 1000)
		{
			Destroy(gameObject);
		}
		else if (d >= 1000)
		{
			transform.position = new Vector3(this.camera1.transform.position.x, this.camera1.transform.position.y, this.camera1.transform.position.z + 1100);
		}

	}
}
