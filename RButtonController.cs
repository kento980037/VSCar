using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RButtonController : MonoBehaviour
{
    bool now = false;
    float movePower = 0.15f;
    GameObject camera2;
    // Start is called before the first frame update
    void Start()
    {
        this.camera2 = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (now == true)
        {
            if (this.camera2.transform.position.x <= 5f)
            {
                Vector3 temp = new Vector3(this.camera2.transform.position.x + movePower, this.camera2.transform.position.y, this.camera2.transform.position.z);
                this.camera2.transform.position = temp;
            }
        }
    }

    public void OnRD()
    {
        now = true;
    }

    public void OnRU()
    {
        now = false;
    }
}
