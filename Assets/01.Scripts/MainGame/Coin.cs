using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Vector2 _velocity = Vector2.zero;

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
            GameObject.Destroy(gameObject);
        }
    }
}
