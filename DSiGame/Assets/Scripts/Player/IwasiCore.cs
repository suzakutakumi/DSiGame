using System;
using UnityEngine;

namespace Player
{
    public class IwasiCore : MonoBehaviour
    {
        public int id;
        public int type;
        public int sizeOfGroup;
        public int attack;
        public int guard;
        public int x, y;
        public int moveRange;
        
        private MoveStruct move;
        [SerializeField]
        private HTTPRequest req;
        
        public void SetStatusFromTemp(IwasiSettingTemp iwasiSettingTemp)
        {
            type = iwasiSettingTemp.type;
            sizeOfGroup = iwasiSettingTemp.sizeOfGroup;
            attack = iwasiSettingTemp.attack;
            guard = iwasiSettingTemp.guard;
            moveRange = iwasiSettingTemp.moveRange;
        }
        
        public void MoveGroup(float x, float y)
        {
            Debug.Log(x + ", " + y);
            this.transform.position = new Vector3(x, 1, y);
            this.x = (int)x;
            this.y = (int)y;
            string body = JsonUtility.ToJson(move);
            req.POST("https://fishevolution.herokuapp.com/moveGroup",body);
        }

        public void Damaged(IwasiCore enemy)
        {
            Debug.Log("Damaged" + enemy.attack / this.guard);

            GiveOrTake(-(enemy.attack / this.guard));
        }

        public void GiveOrTake(int val)
        {
            this.sizeOfGroup += val;
            if (this.sizeOfGroup < 0)
            {
                Destroy(this.gameObject);
            }
        }

        public void Evolution()
        {
            this.type++;
        }
    }
}
