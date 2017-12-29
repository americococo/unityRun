using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerCharacter : MonoBehaviour
{
    //유니티 제공


    //오브젝트 시작될때 호출 되는 함수
    void Start()
    {
        ChangeState(eState.RUN);
    }

    // 프레임 마다 호출
    void Update()
    {

    }

    //캐릭터의 상태
    public enum eState
    {
        IDLE,
        RUN
    };

    void ChangeState(eState state)
    {
        switch (state)
        {

            case eState.IDLE:
                _veloctity.x = 0.0f;
                _veloctity.y = 0.0f;
                GetAnimator().SetBool("isGround", true);
                break;
            case eState.RUN:
                _veloctity.x = 5.0f;
                _veloctity.y = 0.0f;
                GetAnimator().SetBool("isGround", true);
                GetAnimator().SetFloat("Horizontal", _veloctity.x);
                break;
        }
    }

    Vector2 _veloctity = Vector2.zero;


    public Vector2 GetVelocity()
    {
        return _veloctity;
    }

    //animator

    Animator GetAnimator()
    {
        return gameObject.GetComponent<Animator>();
    }
}
