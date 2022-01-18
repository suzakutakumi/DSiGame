using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour
{
    [SerializeField]private GameManager _gameManager;
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    public void SetInfo(IwasiCore iwasiCore)
    {
        _text.text = "群れナンバー：" + iwasiCore.id + "\n出世段階：" + iwasiCore.type + "\n群れの大きさ:" + iwasiCore.sizeOfGroup + "\n攻撃力：" + iwasiCore.attack + "\n防御力：" + iwasiCore.guard + "\n座標：" + iwasiCore.x + "," + iwasiCore.y;
    }
}
