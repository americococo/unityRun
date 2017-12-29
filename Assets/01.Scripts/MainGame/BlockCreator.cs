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
        if(_createInteval <= _createDuration)
        {
            _createDuration = 0.0f;
            CreateBlock();
        }
        _createDuration += Time.deltaTime;
    }


    //state
    bool _isCreate = false;
    public void StartCreate()
    {
        _isCreate = true;
    }



    //block
    public GameObject BlockPrefabs;

    private float _createInteval=0.5f;
    private float _createDuration;

    private void CreateBlock()
    {
        //prefab 오브젝트 인스턴스화
        GameObject blockObject = GameObject.Instantiate(BlockPrefabs);

        //transform-> 위치 각 크기 
        blockObject.transform.position = transform.position;
        GameObject.Destroy(blockObject, 6.0f);
    }
}
