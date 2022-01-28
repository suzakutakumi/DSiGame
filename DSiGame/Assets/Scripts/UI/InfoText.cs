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

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void SetInfo(GameObject iwasi)
    {
        IwasiCore iwasiCore = iwasi.GetComponent<IwasiCore>();
        _text.text = "群れナンバー：" + iwasiCore.id + 
                     "\n出世段階：" + iwasiCore.type + 
                     "\n群れの大きさ:" + iwasiCore.sizeOfGroup + 
                     "\n攻撃力：" + iwasiCore.attack + 
                     "\n防御力：" + iwasiCore.guard + 
                     "\n座標：" + iwasiCore.x + "," + iwasiCore.y +
                     "\n移動範囲：" + iwasiCore.moveRange;
    }
}
