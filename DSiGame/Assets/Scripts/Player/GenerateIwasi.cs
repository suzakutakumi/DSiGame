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
        private void Start()
        {
            _iwasiSetting = GetComponent<IwasiSetting>();
            _gameManager = GetComponent<GameManager>();

            //テスト用
            Generate(0,type,0,0);
            Generate(0,type,10,0);
            Generate(1,type,0,10);
            Generate(1,type,10,10);
        }

        public void Generate(int playerId, int type,int x,int y)
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
                GameObject generatePrefab = Instantiate(prefab, new Vector3(x, 1, y), Quaternion.identity,opponentGroup);
                generatePrefab.GetComponent<IwasiCore>().SetStatusFromTemp(_iwasiSetting.GetIwasiSetting(type));
                _gameManager.AddGroupToOpponentList(generatePrefab);
            }
        }
    }
}
