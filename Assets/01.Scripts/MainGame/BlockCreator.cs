using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (false == _isCreate)
            return;

        //시간 기반
        //if(_createInteval <= _createDuration)
        //{
        //    _createDuration = 0.0f;
        //    CreateBlock();
        //}
        //_createDuration += Time.deltaTime;

        //거리 기반으로 변경
        float distance = transform.position.x - _prevBlockObject.transform.position.x;
        if(_intervalDistance <= distance)//distance 변하는 값
        {
            _prevBlockObject = CreateBlock();
        }

    }


    //state
    bool _isCreate = false;
    public void StartCreate()
    {
        _isCreate = true;

        _prevBlockObject = CreateBlock();
    }



    //preFabs
    public GameObject BlockPrefabs;
    public GameObject Coin1Prefabs;
    public GameObject Coin2Prefabs;

    GameObject _prevBlockObject;

    //test하기위해 public으로
    public float _intervalDistance = 10.0f;

    private GameObject CreateBlock()
    {
        //prefab 오브젝트 인스턴스화
        GameObject blockObject = GameObject.Instantiate(BlockPrefabs);
        blockObject.transform.position = transform.position;

        //GameObject coin1Object = GameObject.Instantiate(Coin1Prefabs);
        //coin1Object.transform.position = new Vector2(transform.position.x, 2.5f);

        //GameObject coin2Object = GameObject.Instantiate(Coin2Prefabs);
        //coin2Object.transform.position = new Vector2(transform.position.x, 6.0f);


        GameObject coin1Object;
        GameObject coin2Object;
        int selectCoin = Random.Range(0, 1000);
        if(selectCoin <500)
        {
            coin1Object = GameObject.Instantiate(Coin1Prefabs);
            coin2Object = GameObject.Instantiate(Coin2Prefabs);
        }
        else
        {
            coin1Object = GameObject.Instantiate(Coin2Prefabs);
            coin2Object = GameObject.Instantiate(Coin1Prefabs);
        }
        coin1Object.transform.position = new Vector2(transform.position.x, 4.0f);
        coin2Object.transform.position = new Vector2(transform.position.x, 8.0f);
        int randValue = Random.Range(0, 1000);
        if(randValue<300)
        {
            blockObject.transform.position = new Vector2(blockObject.transform.position.x, 4.5f);
            coin1Object.transform.position = transform.position;
        }


        return blockObject;
    }
}
