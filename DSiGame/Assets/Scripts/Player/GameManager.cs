using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<GameObject> nowPlayerGroup = new List<GameObject>();
    private List<GameObject> nowOpponentGroup = new List<GameObject>();

    [SerializeField] private PointerMove _pointerMove;

    private void Start()
    {
        
    }

    public void AddGroupToList(GameObject gameObject)
    {
        nowPlayerGroup.Add(gameObject);
    }

    public void SerectGroup(int groupId)
    {
        IwasiMove iwasiMove = nowPlayerGroup[groupId].GetComponent<IwasiMove>();
        _pointerMove.SetMoveGroup(iwasiMove);
    }
}
