using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerCore : MonoBehaviour,IPlayerMove
    {
        private int squareSize = 10;
        
        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 move = context.ReadValue<Vector2>() * squareSize;
            PointerMove(move.x,move.y);
        }
        
        public void OnEnter()
        {
            var position = this.transform.position;
            PlayerMove(position.x, position.z);
        }

        public void PointerMove(float x,float y)
        {
            this.transform.position += new Vector3(x, 0, y);
        }
    
        public void PlayerMove(float x,float y)
        {
            Debug.Log(x + "," + y);
        }
    }
}
