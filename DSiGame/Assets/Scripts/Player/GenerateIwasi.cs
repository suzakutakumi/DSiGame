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
            Generate(type,0,0);
        }

        public void Generate(int type,int x,int y)
        {
            GameObject prefab = _iwasiSetting.GetIwasiSetting(type).prefab;
            GameObject gameObject = Instantiate(prefab, new Vector3(x, 1, y), Quaternion.identity);
            _gameManager.AddGroupToList(gameObject);
        }
    }
}
