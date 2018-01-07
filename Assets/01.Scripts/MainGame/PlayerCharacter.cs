using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//출력 //보요주기용
public class PlayerCharacter : MonoBehaviour
{
    //유니티 제공


    //오브젝트 시작될때 호출 되는 함수
    void Start()
    {
       
    }

    // 프레임 마다 호출
    void Update()
    {
        LayerMask groundMask = 1 << LayerMask.NameToLayer("Ground");//그라운드이름의 레이어를 캐릭터 레이를 통해 검사
        RaycastHit2D hitFromGround = Physics2D.Raycast(transform.position, Vector2.down, 2.0f, groundMask);
        if (null != hitFromGround.transform)
        {
            if (false == _isGround)
            {
                _isGround = true;
                GetAnimator().SetBool("isGround", _isGround);
            }
        }
        else
        {
            if (true == _isGround)
            {
                _isGround = false;
                GetAnimator().SetBool("isGround", _isGround);
            }
        }
    }



    //Init
    Player _player;

    public void Init(Player player)
    {
        _player = player;
    }
    //캐릭터의 상태

    bool _canDoubleJump;
    bool _isGround = false;
    public void Jump(float jumpSpeed)
    {
        if (true == _isGround)
        {
            JumpAction(jumpSpeed);
            if (MainGameManger.instance.GetPlayer().GetCurrentWeight() < 70.0f)
                _canDoubleJump = true;
            else
                _canDoubleJump = false;
        }
        else if (true == _canDoubleJump)
        {
            JumpAction(jumpSpeed);
            _canDoubleJump = false;
        }
    }

    void JumpAction(float jumpSpeed)
    {
        GetAnimator().SetTrigger("Jump");

        //강제로 점프크기 조정
        Vector2 veolocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        veolocity.y = jumpSpeed;
        gameObject.GetComponent<Rigidbody2D>().velocity = veolocity;
    }



    //animator

    Animator GetAnimator()
    {
        return gameObject.GetComponent<Animator>();
    }

    public void IdleState()
    {
        
        GetAnimator().SetFloat("Horizontal", 0.0f);
    }
    public void RunState()
    {

        GetAnimator().SetFloat("Horizontal", 1.0f);
    }

}
