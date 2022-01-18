using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Player
{
    public class GenerateIwasi : MonoBehaviour
    {
        private IwasiSetting _iwasiSetting;
        private GameManager _gameManager;
        private int type = 0;
        private void Start()
        {
            _iwasiSetting = GetComponent<IwasiSetting>();
            _gameManager = GetComponent<GameManager>();
            Generate(0,type,0,0);
            
            //テスト用
            Generate(0,type,10,0);
            Generate(1,type,0,10);
            Generate(1,type,10,10);
        }

        public void Generate(int playerId, int type,int x,int y)
        {
            GameObject prefab = _iwasiSetting.GetIwasiSetting(type).prefab;
            GameObject generatePrefab = Instantiate(prefab, new Vector3(x, 1, y), Quaternion.identity);
            generatePrefab.GetComponent<IwasiCore>().SetStatusFromTemp(_iwasiSetting.GetIwasiSetting(type));
            if (playerId == _gameManager.myId)
            {
                _gameManager.AddGroupToPlayerList(generatePrefab);
            }
            else if (playerId == _gameManager.opponentId)
            {
                _gameManager.AddGroupToOpponentList(generatePrefab);
            }
        }
    }
}
