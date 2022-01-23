using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PointerMove : MonoBehaviour
    {
        private int squareSize = 10;
        private IwasiCore moveGroup;
        
        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Vector2 move = context.ReadValue<Vector2>() * squareSize;
                MovePointer(move.x, move.y);
            }
        }
        
        public void OnEnter(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Vector3 position = this.transform.position;
                if (moveGroup!=null)
                {
                    moveGroup.MoveGroup(position.x, position.z);
                }
                else Debug.Log("操作する群れを選んでください");
            }
        }

        public void SetIwasi(IwasiCore iwasiCore)
        {
            moveGroup = iwasiCore;
        }

        private void MovePointer(float x,float y)
        {
            this.transform.position += new Vector3(x, 0, y);
        }
    }
}
