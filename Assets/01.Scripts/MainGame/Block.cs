using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Vector2 _velocity = Vector2.zero;

    //유니티 제공 함수
    void Start()
    {
       
    }

    void Update()
    {

    }

    bool IS_collison=false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ("Player" == collision.tag)
        {
            if (false == IS_collison)
            {
                MainGameManger.instance.GetPlayer().RestSpeed();
                IS_collison = true;
            }
        }
    }
}
