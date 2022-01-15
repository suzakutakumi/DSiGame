using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTTPRequestTest : MonoBehaviour
{
    private MoveStruct move;
    [SerializeField]
    private HTTPRequest req;
    void Start()
    {
        move = new MoveStruct();
        move.number = 0;
        move.playerId = 1;
        move.isMove = true;
        move.groupId = 10;
        move.x = 2;
        move.y = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            req.GET("http://localhost:8080/moveGroup?number="+move.number.ToString());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            string body = JsonUtility.ToJson(move);
            req.POST("http://localhost:8080/moveGroup",body);
        }
        if (req.result != null)
        {
            var res=MoveStruct.Deserialize(req.result);
            Debug.Log(JsonUtility.ToJson(res));
            req.result = null;
        }
    }
}
