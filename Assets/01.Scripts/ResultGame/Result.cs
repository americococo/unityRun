using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    public Text Score;
    int score=0;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (MainGameManger.instance.GetPlayer().IsSuccess())
        {
            score += 300;
        }
        if (5.0f < MainGameManger.instance.GetPlayer().iSComPlete())
        {
            score += 100;
        }
        else
        {
            score += 50;
        }
        if ( 20.0f<MainGameManger.instance.GetPlayer().GetCurrentHP())
        {
            score += 100;
        }

    }
}
