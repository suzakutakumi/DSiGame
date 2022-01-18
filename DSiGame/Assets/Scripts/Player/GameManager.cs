using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class GameManager : MonoBehaviour
    {
        public List<GameObject> nowPlayerGroup = new List<GameObject>();
        public List<GameObject> nowOpponentGroup = new List<GameObject>();
        public int myId;
        public int opponentId;

        [SerializeField] private PointerMove _pointerMove;
        [SerializeField] private GenerateButton _generateButton;
        private IwasiCore iwasiCore;

        private void Start()
        {
            myId = 0;
            opponentId = 1;
        }

        public void SetPlayerId(int player,int opponent)
        {
            myId = player;
            opponentId = opponent;
        }

        public void AddGroupToPlayerList(GameObject gameObject)
        {
            nowPlayerGroup.Add(gameObject);
            _generateButton.Generate(nowPlayerGroup.Count-1);
        }

        public void AddGroupToOpponentList(GameObject gameObject)
        {
            nowOpponentGroup.Add(gameObject);
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
