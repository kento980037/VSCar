using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loclizeController : MonoBehaviour
{ 
	public string eng;


	// Start is called before the first frame update
	void Start()
    {
		if (Application.systemLanguage != SystemLanguage.Japanese)
		{
			this.GetComponent<Text>().text = eng;
		}

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*
   \n Although this game is a game in which the theme is "tailgating car", do not imitate a tailgating car that appears in the game on actual public roads. Tailgating car is a malicious and dangerous car that can lead to serious accidents. If you see a tailgating car, go to a safe place and call police immediately. Drive recorders are also useful for both deterrence and recording. It is also important not to be mistaken for being a perpetrator on tailgating. When another car breaks in, you may be frustrated for a moment. But you have to be patient. Traffic safety is achieved through the caring of each and every driver. It is a smart driver who does not become a victim or assailant of tailgating, driving caring following traffic rules.
\n Also, the user shall be responsible for any losses that may occur through playing the game.
*/
