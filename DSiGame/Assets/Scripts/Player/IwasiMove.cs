using UnityEngine;

namespace Player
{
    public class IwasiMove : MonoBehaviour
    {
        public void MoveGroup(float x, float y)
        {
            Debug.Log(x + ", " + y);
            this.transform.position = new Vector3(x, 1, y);
        }
    }
}
