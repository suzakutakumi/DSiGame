using UnityEngine;

namespace Player
{
    public class KariIwasiCore : MonoBehaviour
    {
        public void MoveGroup(float x, float y)
        {
            Debug.Log("aaa");
            this.transform.position += new Vector3(x, 0, y);
        }
    }
}
