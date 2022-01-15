using UnityEngine;

namespace Player
{
    public class GroupCore : MonoBehaviour
    {
        public void MoveGroup(float x, float y)
        {
            Debug.Log("aaa");
            this.transform.position += new Vector3(x, 0, y);
        }
    }
}
