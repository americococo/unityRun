using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeightSlider : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        float maxWeight = MainGameManger.instance.GetPlayer().GetMaxWeight();
        float minWeight = MainGameManger.instance.GetPlayer().GetMinWeight();
        float currentWeight = MainGameManger.instance.GetPlayer().GetCurrentWeight();

        float maxLength = maxWeight - minWeight;
        float CurrentLength =  currentWeight- minWeight;
        float rate =  CurrentLength / maxLength;

        gameObject.GetComponent<Slider>().value = rate;

        if (MainGameManger.instance.GetPlayer().IsSuccess())
        {
            gameObject.gameObject.SetActive(false);
        }
    }
}
