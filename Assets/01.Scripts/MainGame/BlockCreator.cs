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



    //block
    public GameObject BlockPrefabs;

    //private float _createInteval=0.5f;
    //private float _createDuration;
    GameObject _prevBlockObject;

    //test하기위해 public으로
    public float _intervalDistance = 10.0f;

    private GameObject CreateBlock()
    {
        //prefab 오브젝트 인스턴스화
        GameObject blockObject = GameObject.Instantiate(BlockPrefabs);

        //transform-> 위치 각 크기 
        blockObject.transform.position = transform.position;

        int randValue = Random.Range(0, 1000);
        if(randValue<300)
        {
            blockObject.transform.position = new Vector2(blockObject.transform.position.x, 2.5f);
        }

        //임시 주석추리
        //GameObject.Destroy(blockObject, 6.0f);

        return blockObject;
    }
}
