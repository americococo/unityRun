using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float AddWeight = 0.0f;
    public float AddHP = 0.0f;

    //유니티 제공 함수
    void Start()
    {
       
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ("Player" == collision.tag)
        {
            MainGameManger.instance.GetPlayer().AddWeight(AddWeight);
            MainGameManger.instance.GetPlayer().InCreaseHP(AddHP);
            GameObject.Destroy(gameObject);
        }
    }
}
