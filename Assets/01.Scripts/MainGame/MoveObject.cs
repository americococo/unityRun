using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
    
    //캐릭터이동속도에 맞춰어서 오브젝트 이동 장애물,코인 등...

    Vector2 _velocity = Vector2.zero;

    //유니티 제공 함수
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = _velocity;
    }

    void Update()
    {
        Vector2 playerVelocity = MainGameManger.instance.GetPlayer().GetVelocity();
        if (playerVelocity != _velocity)
        {
            _velocity = playerVelocity;
            gameObject.GetComponent<Rigidbody2D>().velocity = -_velocity;
        }
        if (transform.position.x < -25)
        {
            GameObject.Destroy(gameObject, 2.0f);
        }
    }
}
