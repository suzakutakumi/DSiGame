using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAction : MonoBehaviour
{
    [SerializeField]
    public BaseActions actions;
    [SerializeField]
    private HTTPRequest req;

    // Start is called before the first frame update
    void Start()
    {
        string json = "{\"fromId\":0,\"toId\":100,\"newId\":31,\"x\":10,\"z\":20,\"moveCount\":12}";

        Debug.Log(json);

        actions = BaseActions.Deserialize(json);
    }

    // Update is called once per frame
    void Update()
    {
    //    if (敵の行動終わったら)
    //    {
    //        req.GET("http://localhost:8080/moveGroup?number=" + move.number.ToString());
    //    }
    //    if (自分の行動が終わったら)
    //    {
    //        string body = JsonUtility.ToJson(move);
    //        req.POST("http://localhost:8080/moveGroup", body);
    //    }
    //    if (req.result != null)
    //    {
    //        var res = MoveStruct.Deserialize(req.result);
    //        Debug.Log(JsonUtility.ToJson(res));
    //        req.result = null;
    //    }
    }
}
