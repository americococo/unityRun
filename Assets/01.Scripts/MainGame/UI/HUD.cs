﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    public Text WeightText;
    public Text MaxSpeedText;
    public Text CurrentSpeedText;
    public Text JumpInfoText;
    public Text RemainingDistanceText;


    void Start()
    {

    }

    void Update()
    {
        WeightText.text = "체중" + MainGameManger.instance.GetPlayer().GetCurrentWeight().ToString("N2") + "/" +
           MainGameManger.instance.GetPlayer().GetGoalWeight(); ;
        MaxSpeedText.text = "최대속도 " + MainGameManger.instance.GetPlayer().GetmaxSpeed();
        CurrentSpeedText.text = "속도" + MainGameManger.instance.GetPlayer().GetSpeed().ToString("N2");
        
        if(MainGameManger.instance.GetPlayer().CanDoubleJump())
        {
            JumpInfoText.text = "더블점프여부:가능";
        }
        else
        {
            JumpInfoText.text = "더블점프여부:불가";
        }

        float remainDistance = MainGameManger.instance.GetPlayer().getMaxDistance() - MainGameManger.instance.GetPlayer().GetDistance();
        RemainingDistanceText.text = "남은거리" + remainDistance.ToString("N2");

    }
}