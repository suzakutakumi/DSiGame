using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private ActionManager _actionManager;
    [SerializeField] private GameManager _gameManager;
    private IwasiCore _iwasiCore;
    void Start()
    {
        _actionManager.getID(_iwasiCore.id,0);
    }

    public void SetAction(IwasiCore iwasiCore)
    {
        _iwasiCore = iwasiCore;
    }
    
    
}
