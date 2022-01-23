using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Player
{
    public class GenerateIwasi : MonoBehaviour
    {
        public Transform myGroup;
        public Transform opponentGroup;
        
        private IwasiSetting _iwasiSetting;
        private GameManager _gameManager;
        private int type = 0;
        private void Awake()
        {
            _iwasiSetting = GetComponent<IwasiSetting>();
            _gameManager = GetComponent<GameManager>();

            //テスト用
            InitialGenerate(0,type,0,0);
            InitialGenerate(0,type,10,0);
            InitialGenerate(1,type,0,10);
            InitialGenerate(1,type,10,10);
        }

        public void InitialGenerate(int playerId,int type,int x,int y)
        {
            GameObject prefab = _iwasiSetting.GetIwasiSetting(type).prefab;
            if (playerId == _gameManager.myId)
            {
                GameObject generatePrefab = Instantiate(prefab, new Vector3(x, 1, y), Quaternion.identity,myGroup);
                generatePrefab.GetComponent<IwasiCore>().SetStatusFromTemp(_iwasiSetting.GetIwasiSetting(type));
                _gameManager.AddGroupToPlayerList(generatePrefab);
            }
            if (playerId == _gameManager.opponentId)
            {
                GameObject generatePrefab = Instantiate(prefab, new Vector3(x, 1, y), new Quaternion(0,180,0,0),opponentGroup);
                generatePrefab.GetComponent<IwasiCore>().SetStatusFromTemp(_iwasiSetting.GetIwasiSetting(type));
                _gameManager.AddGroupToOpponentList(generatePrefab);
            }
        }
    }
}
