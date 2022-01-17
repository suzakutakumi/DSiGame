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

        public void SetStatusFromTemp(IwasiSettingTemp iwasiSettingTemp)
        {
            type = iwasiSettingTemp.type;
            sizeOfGroup = iwasiSettingTemp.sizeOfGroup;
            attack = iwasiSettingTemp.attack;
            guard = iwasiSettingTemp.guard;
        }
        
        public void MoveGroup(float x, float y)
        {
            Debug.Log(x + ", " + y);
            this.transform.position = new Vector3(x, 1, y);
        }
    }
}
