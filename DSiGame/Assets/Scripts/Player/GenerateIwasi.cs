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
        }

        public void InitialGenerate(int playerID,int type,int x,int y)
        {
            GameObject prefab = _iwasiSetting.GetIwasiSetting(type).prefab;
            if (playerID == _gameManager.myId)
            {
                GameObject generatePrefab = Instantiate(prefab, new Vector3(x, 1, y), Quaternion.identity,myGroup);
                generatePrefab.GetComponent<IwasiCore>().SetStatusFromTemp(_iwasiSetting.GetIwasiSetting(type));
                generatePrefab.GetComponent<IwasiCore>().x = x;
                generatePrefab.GetComponent<IwasiCore>().y = y;
                _gameManager.AddGroupToPlayerList(generatePrefab);
            }
            if (playerID == _gameManager.opponentId)
            {
                GameObject generatePrefab = Instantiate(prefab, new Vector3(x, 1, y), new Quaternion(0,180,0,0),opponentGroup);
                generatePrefab.GetComponent<IwasiCore>().SetStatusFromTemp(_iwasiSetting.GetIwasiSetting(type));
                generatePrefab.GetComponent<IwasiCore>().x = x;
                generatePrefab.GetComponent<IwasiCore>().y = y;
                _gameManager.AddGroupToOpponentList(generatePrefab);
            }
        }

        public void Generate(int playerID,int size,int type,int x,int y)
        {
            GameObject prefab = _iwasiSetting.GetIwasiSetting(type).prefab;
            if (playerID == _gameManager.myId)
            {
                GameObject generatePrefab = Instantiate(prefab, new Vector3(x, 1, y), Quaternion.identity,myGroup);
                generatePrefab.GetComponent<IwasiCore>().SetStatusFromTemp(_iwasiSetting.GetIwasiSetting(type));
                generatePrefab.GetComponent<IwasiCore>().sizeOfGroup = size;
                generatePrefab.GetComponent<IwasiCore>().x = x;
                generatePrefab.GetComponent<IwasiCore>().y = y;
                _gameManager.AddGroupToPlayerList(generatePrefab);
            }
            if (playerID == _gameManager.opponentId)
            {
                GameObject generatePrefab = Instantiate(prefab, new Vector3(x, 1, y), new Quaternion(0,180,0,0),opponentGroup);
                generatePrefab.GetComponent<IwasiCore>().SetStatusFromTemp(_iwasiSetting.GetIwasiSetting(type));
                generatePrefab.GetComponent<IwasiCore>().sizeOfGroup = size;
                generatePrefab.GetComponent<IwasiCore>().x = x;
                generatePrefab.GetComponent<IwasiCore>().y = y;
                _gameManager.AddGroupToOpponentList(generatePrefab);
            }
            
        }
    }
}
