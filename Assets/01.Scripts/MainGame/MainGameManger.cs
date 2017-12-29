using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//싱글턴
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
        
    }

    void Update()
    {
        
    }

    public PlayerCharacter PlayerCharacterScr;

    public PlayerCharacter GetPlayer()
    {
        return PlayerCharacterScr;
    }
}
