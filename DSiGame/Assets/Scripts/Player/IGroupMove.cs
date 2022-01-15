using UnityEngine;

namespace Player
{
    public interface IGroupMove
    {
        public void SetMoveGroup(GameObject group);
        public void MoveGroup(float x,float y);
    }
}
