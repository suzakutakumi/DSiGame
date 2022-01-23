using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PointerMove : MonoBehaviour
    {
        private int squareSize = 10;
        [SerializeField] private IwasiCore moveGroup;
        
        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Vector2 move = context.ReadValue<Vector2>() * squareSize;
                float deltaX = transform.position.x - moveGroup.x + move.x;
                float deltaY = transform.position.z - moveGroup.y + move.y;
                
                if (Mathf.Abs(deltaX) <= moveGroup.moveRange * squareSize &&
                    Mathf.Abs(deltaY) <= moveGroup.moveRange * squareSize &&
                    transform.position.x + move.x >= 0 && transform.position.z + move.y >= 0) 
                {
                    MovePointer(move.x, move.y);
                }
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
            transform.position = new Vector3(moveGroup.x, 4, moveGroup.y);
        }

        private void MovePointer(float x,float y)
        {
            this.transform.position += new Vector3(x, 0, y);
        }
    }
}
