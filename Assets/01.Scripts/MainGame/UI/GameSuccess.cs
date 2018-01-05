using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSuccess : MonoBehaviour
{

    public Text GameSuccessText;
    // Use this for initialization
    void Start()
    {
        GameSuccessText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(MainGameManger.instance.GetPlayer().IsSuccess())
        {
            if(MainGameManger.instance.GetPlayer().iSComPlete())
            {
                GameSuccessText.text = "GOOD";
            }
            else
            {
                GameSuccessText.text = "FAil";
            }

            GameSuccessText.gameObject.SetActive(true);
        }
    }
}
