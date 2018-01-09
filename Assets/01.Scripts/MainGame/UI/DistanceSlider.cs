using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DistanceSlider : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float Goal = MainGameManger.instance.GetPlayer().getMaxDistance();
        float Current_Distance = MainGameManger.instance.GetPlayer().GetDistance();
        float Rate = Current_Distance / Goal;
        gameObject.GetComponent<Slider>().value = Rate;

        if (MainGameManger.instance.GetPlayer().IsSuccess())
        {
           gameObject.gameObject.SetActive(false);   
        }
    }

}
