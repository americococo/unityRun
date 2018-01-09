using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreParent : MonoBehaviour
{
    public Text ScoreText;
    float score;
    void Start()
    {
        score = MainGameManger.instance.GetPlayer().GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + ((int)score).ToString();
    }
}
