using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PointerMove : MonoBehaviour
    {
        private int squareSize = 10;
        private IwasiCore moveGroup;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameObject cameraObject;
        
        private MoveRangeLine _line;
        private CreateStage _createStage;

        private void Start()
        {
            _line = GetComponent<MoveRangeLine>();
            _createStage = GameObject.Find("PointCreateStage").GetComponent<CreateStage>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Vector2 move = context.ReadValue<Vector2>() * squareSize;
                float deltaX = transform.position.x - moveGroup.x + move.x;
                float deltaY = transform.position.z - moveGroup.y + move.y;
                float supX = _createStage.X * _createStage.GridSize * squareSize - _createStage.GridSize * squareSize / 2;
                float supZ = _createStage.Z * _createStage.GridSize * squareSize - _createStage.GridSize * squareSize / 2;
                
                if (Mathf.Abs(deltaX) <= moveGroup.moveRange * squareSize &&
                    Mathf.Abs(deltaY) <= moveGroup.moveRange * squareSize &&
                    transform.position.x + move.x >= 0 && transform.position.z + move.y >= 0 &&
                    transform.position.x + move.x <= supX && transform.position.z + move.y <= supZ) 
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
                    _line.DrawLine(moveGroup);
                }
                else Debug.Log("操作する群れを選んでください");
            }
        }

        public void SetIwasi(GameObject iwasi)
        {
            if (gameManager.myId == 0)
            {
                cameraObject.transform.localPosition = new Vector3(0, 4, -10);
                cameraObject.transform.localRotation = Quaternion.Euler(20,0,0);
            }
            else if (gameManager.myId == 1)
            {
                cameraObject.transform.localPosition = new Vector3(0, 4, 10);
                cameraObject.transform.localRotation = Quaternion.Euler(20,180,0);
            }
            moveGroup = iwasi.GetComponent<IwasiCore>();
            transform.position = new Vector3(moveGroup.x, 4, moveGroup.y);
            _line.DrawLine(moveGroup);
        }

        private void MovePointer(float x,float y)
        {
            if (gameManager.myId == 0)
            {
                transform.position += new Vector3(x, 0, y);
            }
            else if (gameManager.myId == 1)
            {
                transform.position += new Vector3(-x, 0, -y);
            }
        }
    }
}
