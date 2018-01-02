using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어 관련 알고리즘 (상태 ,입력, 등등 )
public class Player : MonoBehaviour
{
    public PlayerCharacter PlayerView;

    void Start()
    {
        PlayerView.Init(this);
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            PlayerView.Jump(_jumpSpeed);
        }

        if(eState.RUN==_state)
        {
            if(_veloctity.x < _maxSpeed)
            {
                _veloctity.x += _addSpeed;
            }
            else
            {
                _veloctity.x = _maxSpeed;
            }
        }
    }

    public enum eState
    {
        IDLE,
        RUN
    };

    eState _state= eState.IDLE;

    //test하기위해 public으로
    public float _maxSpeed = 35.0f;
    public float _addSpeed = 0.01f;

    public float _jumpSpeed = 10.0f;

    public void ChangeState(eState state)
    {
        _state = state;
        switch (state)
        {

            case eState.IDLE:
                _veloctity.x = 0.0f;
                _veloctity.y = 0.0f;
                PlayerView.IdleState();
                break;
            case eState.RUN:
                _veloctity.x = 0.0f;
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
    public void RestSpeed()
    {
        _veloctity.x=0.0f;
    }
}
