using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class GameManager : MonoBehaviour
    {
        public List<GameObject> nowPlayerGroup = new List<GameObject>();
        private List<GameObject> nowOpponentGroup = new List<GameObject>();
        public int nowGroupId = 0;

        [SerializeField] private PointerMove _pointerMove;
        [SerializeField] private GenerateButton _generateButton;
        private IwasiCore iwasiCore;

        private void Start()
        {
        
        }

        public void AddGroupToList(GameObject gameObject)
        {
            nowPlayerGroup.Add(gameObject);
            _generateButton.Generate(nowPlayerGroup.Count-1);
        }

        public void SerectGroup(int groupId)
        {
            Debug.Log("select" + groupId);
            iwasiCore = nowPlayerGroup[groupId].GetComponent<IwasiCore>();
            _pointerMove.SetIwasi(iwasiCore);
        }

        public void MoveGroup(int x, int y)
        {
            iwasiCore.MoveGroup(x*10,y*10);
        }
    }
}
