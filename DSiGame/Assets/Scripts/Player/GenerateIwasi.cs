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
                GameObject generatePlayerPrefab = Instantiate(prefab, new Vector3(x, 1, y), Quaternion.identity, myGroup);;
                if (_gameManager.myId == 0)
                {
                    generatePlayerPrefab.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (_gameManager.myId == 1)
                {
                    generatePlayerPrefab.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                generatePlayerPrefab.GetComponent<IwasiCore>().SetStatusFromTemp(_iwasiSetting.GetIwasiSetting(type));
                generatePlayerPrefab.GetComponent<IwasiCore>().x = x;
                generatePlayerPrefab.GetComponent<IwasiCore>().y = y;
                _gameManager.AddGroupToPlayerList(generatePlayerPrefab);
            }
            else if (playerID == _gameManager.opponentId)
            {
                GameObject generateOpponentPrefab = Instantiate(prefab, new Vector3(x, 1, y), Quaternion.identity, opponentGroup);;
                if (_gameManager.opponentId == 0)
                {
                    generateOpponentPrefab.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (_gameManager.opponentId == 1)
                {
                    generateOpponentPrefab.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                generateOpponentPrefab.GetComponent<IwasiCore>().SetStatusFromTemp(_iwasiSetting.GetIwasiSetting(type));
                generateOpponentPrefab.GetComponent<IwasiCore>().x = x;
                generateOpponentPrefab.GetComponent<IwasiCore>().y = y;
                _gameManager.AddGroupToOpponentList(generateOpponentPrefab);
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
