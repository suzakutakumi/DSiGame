using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class HTTPRequestTest : MonoBehaviour
{
    private MoveStruct move;
    [SerializeField]
    private HTTPRequest req;

    [SerializeField] private GameManager _gameManager;
    
    void Start()
    {
        move = new MoveStruct();
        move.number = 0;
        move.playerId = 0;
        move.isMove = true;
        move.groupId = 0;
        move.x = 2;
        move.y = 4;
        req.result = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            req.GET("https://fishevolution.herokuapp.com/moveGroup?number="+move.number.ToString());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            string body = JsonUtility.ToJson(move);
            req.POST("https://fishevolution.herokuapp.com/moveGroup",body);
        }
        if (req.result != null)
        {
            var res=MoveStruct.Deserialize(req.result);
            Debug.Log(JsonUtility.ToJson(res));
            _gameManager.SerectGroup(res.groupId);
            _gameManager.MoveGroup(res.x,res.y);
            req.result = null;
        }else Debug.Log("reqはnull！！");
    }
}
