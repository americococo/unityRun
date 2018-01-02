using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Vector2 _velocity = Vector2.zero;

    //유니티 제공 함수
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = _velocity;
    }

    void Update()
    {
        Vector2 playerVelocity = MainGameManger.instance.GetPlayer().GetVelocity();
        if(playerVelocity != _velocity)
        {
            _velocity = playerVelocity;
            gameObject.GetComponent<Rigidbody2D>().velocity = -_velocity;
        }
        if(transform.position.x < -15)
        {
            GameObject.Destroy(gameObject, 5.0f);
        }
    }
}
