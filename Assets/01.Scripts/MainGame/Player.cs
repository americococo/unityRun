using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//플레이어 관련 알고리즘 (상태 ,입력, 등등 )
public class Player : MonoBehaviour
{
    public PlayerCharacter PlayerView;

    void Start()
    {
        _currentWeight = _startWeight;
        _currentHP = _maxHP;
        _distance = 0.0f;

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
            UpdateDistance();
            if (_veloctity.x < _maxSpeed)
            {
                _veloctity.x += _addSpeed;
            }
            else
            {
                _veloctity.x = _maxSpeed;
            }

            UpdateWeight();
            UpdateHP();

            UpdateSpeedByWeight();
        }
        if(_state== eState.COMPLETE)
        {
            SceneManager.LoadScene("ResultScreen");
        }

    }
    void UpdateDistance()
    {
        //거리 = 시간 * 속도
        float deltaDistance = _veloctity.x * Time.deltaTime;
        _distance += deltaDistance;

        if(_maxDistance <= _distance)
        {
            ChangeState(eState.COMPLETE);
        }
    }

    void UpdateWeight()
    {
        _decreaseWeight = (_currentWeight-40.0f ) / 100.0f;//140 < > 40

        if (_decreaseWeight >= 0.2f)
            _decreaseWeight = 0.2f;

        _currentWeight -= _decreaseWeight;
        if (_currentWeight < _minWeight)
            _currentWeight = _minWeight;
        if (_currentWeight > _maxWeight)
            _currentWeight = _maxWeight;


        transform.localScale = new Vector3(_currentWeight/60.0f,1.0f,1.0f);
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

    void UpdateSpeedByWeight()
    {
        if(120.0f < _currentWeight)
        {
            _maxSpeed = 10.0f;
        }
        else if (100.0f < _currentWeight )
        {
            _maxSpeed = 11.0f;
        }
        else if (80.0f < _currentWeight)
        {
            _maxSpeed = 12.5f;
        }
        else if (60.0f < _currentWeight)
        {
            _maxSpeed = 14.0f;
        }
        else if (40.0f <= _currentWeight)
        {
            _maxSpeed = 15.0f;
        }
    }




    public enum eState
    {
        IDLE,
        RUN,
        DEATH,
        COMPLETE,
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

    public float iSComPlete()
    {
        float deltaWeight = _goalWeight - _currentWeight;
        float deltaWeightOffset = Mathf.Abs(deltaWeight);
        Score += (-(MainGameManger.instance.GetPlayer().iSComPlete() * 0.5f));
        Score += 10 * (MainGameManger.instance.GetPlayer().GetCurrentHP() / MainGameManger.instance.GetPlayer().GetMaxHP());
        return deltaWeightOffset;
    }

    float _maxDistance=100.0f;
    float _distance=0.0f;

    public float GetGoalWeight()
    {
        return _goalWeight;
    }

    public float GetDistance()
    {
        return _distance;
    }

    public float getMaxDistance()
    {
        return _maxDistance;
    }

    //Weight
    float _maxWeight = 140.0f;
    float _minWeight = 40.0f;
    float _startWeight = 100.0f;
    float _decreaseWeight = 0.1f;
    float _currentWeight = 0.0f;
    float _goalWeight = 60.0f;

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
    float _maxSpeed = 15.0f;
    float _addSpeed = 0.05f;
    float _jumpSpeed = 35.0f;

    public float GetmaxSpeed()
    {
        return _maxSpeed;
    }
    public float GetSpeed()
    {
        return _veloctity.x;
    }

    public bool CanDoubleJump()
    {
        if (70.0f > _currentWeight)
            return true;
        else
            return false;
    }

    public bool IsSuccess()
    {
        if (eState.COMPLETE == _state)
            return true;
        return false;
    }

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
            case eState.COMPLETE:
                _veloctity.x = 0.0f;
                _veloctity.y = 0.0f;
                PlayerView.IdleState();
                break;
        }
    }


    Vector2 _veloctity = Vector2.zero;

    float Score;

    public Vector2 GetVelocity()
    {
        return _veloctity;
    }
    public void RestSpeed()
    {
        _veloctity.x=0.0f;
    }
    public float GetScore()
    {
        return Score;
    }
}
