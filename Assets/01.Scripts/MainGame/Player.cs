using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어 관련 알고리즘 (상태 ,입력, 등등 )
public class Player : MonoBehaviour
{
    public PlayerCharacter PlayerView;

    void Start()
    {
        _currentWeight = _startWeight;
        _currentHP = _maxHP;
        PlayerView.Init(this);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerView.Jump(_jumpSpeed);
        }

        if (eState.RUN == _state)
        {
            if (_veloctity.x < _maxSpeed)
            {
                _veloctity.x += _addSpeed;
            }
            else
            {
                _veloctity.x = _maxSpeed;
            }

            UpdateHP();
            UpdateWeight();

        }
    }

    void UpdateWeight()
    {
        _currentWeight -= _decreaseWeight;
        if (_currentWeight < _minWeight)
            _currentWeight = _minWeight;
        if (_currentWeight > _maxWeight)
            _currentWeight = _maxWeight;

    }

    void UpdateHP()
    {
        _currentHP -= _decreaseHP;

        if (_currentHP <= 0)
        {
            _currentHP = 0;

            ChangeState(eState.DEATH);
        }
    }

    public enum eState
    {
        IDLE,
        RUN,
        DEATH,
    };

    eState _state = eState.IDLE;
    
    //HP
    float _maxHP = 100.0f;
    float _decreaseHP = 0.1f;
    float _currentHP = 0.0f;

    public float GetMaxHP()
    {
        return _maxHP;
    }

    public float GetCurrentHP()
    {
        return _currentHP;
    }

    public void InCreaseHP(float addHP)
    {
        _currentHP += addHP;
        if (_maxHP < _currentHP)
            _currentHP = _maxHP;
    }

    public bool IsDead()
    {
        if (eState.DEATH == _state)
            return true;
        else
            return false;
    }

    //Weight
    float _maxWeight = 140.0f;
    float _minWeight = 40.0f;
    float _startWeight = 100.0f;
    float _decreaseWeight = 0.1f;
    float _currentWeight = 0.0f;

    public float GetMaxWeight()
    {
        return _maxWeight;
    }
    public float GetMinWeight()
    {
        return _minWeight;
    }
    public float GetCurrentWeight()
    {
        return _currentWeight;
    }
    public void AddWeight(float AddWeight)
    {
        _currentWeight += AddWeight;
        if (_minWeight > _currentWeight)
            _currentWeight = _minWeight;
        if (_maxWeight < _currentWeight)
            _currentWeight = _maxWeight;
    }

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
            case eState.DEATH:
                _veloctity.x = 0.0f;
                _veloctity.y = 0.0f;
                PlayerView.IdleState();
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
