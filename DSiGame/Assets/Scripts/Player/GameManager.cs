using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class GameManager : MonoBehaviour
    {
        public List<GameObject> nowPlayerGroup = new List<GameObject>();
        public List<GameObject> nowOpponentGroup = new List<GameObject>();
        public static RoomStruct room;
        public int myId;
        public int opponentId;

        [SerializeField] private PointerMove _pointerMove;
        [SerializeField] private GenerateButton _generateButton;
        [SerializeField] private InfoText _infoText;
        [SerializeField] private ActionManager _actionManager;
        [SerializeField] private GenerateIwasi _generateIwasi;
        private IwasiCore iwasiCore;

        private void Awake()
        {
            if (room != null)
            {
                if (room.isFirst)
                {
                    SetPlayerId(0, 1);
                }
                else
                {
                    SetPlayerId(1, 0);
                }
            }
            else
            {
                //テスト用（タイトルシーンから移動しなかった場合）
                SetPlayerId(0, 1);
            }
            _generateIwasi.InitialGenerate(0,0,0,0);
            _generateIwasi.InitialGenerate(1,0,90,90);
            SerectGroup(0);
        }

        public void SetPlayerId(int player,int opponent)
        {
            myId = player;
            opponentId = opponent;
        }

        public void AddGroupToPlayerList(GameObject gameObject)
        {
            nowPlayerGroup.Add(gameObject);
            gameObject.GetComponent<IwasiCore>().id = nowPlayerGroup.Count - 1;
            _generateButton.Generate(nowPlayerGroup.Count-1);
        }

        public void AddGroupToOpponentList(GameObject gameObject)
        {
            nowOpponentGroup.Add(gameObject);
            gameObject.GetComponent<IwasiCore>().id = nowOpponentGroup.Count - 1;
        }

        public void SerectGroup(int groupId)
        {
            Debug.Log("select" + groupId);
            iwasiCore = nowPlayerGroup[groupId].GetComponent<IwasiCore>();
            _actionManager.SetAction(iwasiCore);
            _infoText.SetInfo(iwasiCore);
            _pointerMove.SetIwasi(iwasiCore);
        }

        public void SerectOpponentGroup(int groupId)
        {
            iwasiCore = nowOpponentGroup[groupId].GetComponent<IwasiCore>();
            _pointerMove.SetIwasi(iwasiCore);
        }

        public void MoveGroup(int x, int y)
        {
            iwasiCore.MoveGroup(x*10,y*10);
        }
    }
}
