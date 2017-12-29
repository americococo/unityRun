using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어 관련 알고리즘 (상태 ,입력, 등등 )
public class Player : MonoBehaviour
{
    public PlayerCharacter PlayerView;

    void Start()
    {
        ChangeState(eState.IDLE);
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            PlayerView.Jump();
        }
    }

    public enum eState
    {
        IDLE,
        RUN,
        JUMP
    };

    public void ChangeState(eState state)
    {
        switch (state)
        {

            case eState.IDLE:
                _veloctity.x = 0.0f;
                _veloctity.y = 0.0f;
                PlayerView.IdleState();
                break;
            case eState.RUN:
                _veloctity.x = 5.0f;
                _veloctity.y = 0.0f;
                PlayerView.RunState();
                break;
        }
    }


    Vector2 _veloctity = Vector2.zero;

    public Vector2 GetVelocity()
    {
        return _veloctity;
    }
}
