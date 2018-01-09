using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//싱글턴

//게임 시작 (적합)
public class MainGameManger : MonoBehaviour
{
    private static MainGameManger _instance;
    public static MainGameManger instance
    {
        get
        {
            if(null == _instance)
            {
                _instance = FindObjectOfType<MainGameManger>();
            }
            return _instance;
        }
    }



    void Start()
    {
        DontDestroyOnLoad(PlayerCharacterScr);
        StartGame();        
    }

    void Update()
    {
        
    }
    //gameState
    void StartGame()
    {
        PlayerCharacterScr.ChangeState(Player.eState.RUN);//시작전에는 IDLE상태
        BlockCreatorScr.StartCreate();//시작전에는 블럭 생성해선 안됌
    }



    //gameObject
    public Player PlayerCharacterScr;
    public BlockCreator BlockCreatorScr;
    public Player GetPlayer()
    {
        return PlayerCharacterScr;
    }
}
