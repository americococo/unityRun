using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPSlider : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        float maxHP = MainGameManger.instance.GetPlayer().GetMaxHP();
        float currentHP = MainGameManger.instance.GetPlayer().GetCurrentHP();
        float rate = currentHP / maxHP;
        gameObject.GetComponent<Slider>().value = rate;

        if (MainGameManger.instance.GetPlayer().IsSuccess())
        {
            gameObject.gameObject.SetActive(false);
        }

    }
}