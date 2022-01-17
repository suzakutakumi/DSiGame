using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PointerMove : MonoBehaviour
    {
        private int squareSize = 10;
        [SerializeField] private IwasiMove moveGroup;
        
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
                MoveGroup(position.x, position.z);
            }
        }

        public void SetMoveGroup(IwasiMove iwasiMove)
        {
            Debug.Log("Set");
            moveGroup = iwasiMove;
        }

        public void MoveGroup(float x, float y)
        {
            moveGroup.MoveGroup(x,y);
        }

        private void MovePointer(float x,float y)
        {
            this.transform.position += new Vector3(x, 0, y);
        }
    }
}
