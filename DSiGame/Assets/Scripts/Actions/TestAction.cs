using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class TestAction : MonoBehaviour
{
    public BaseActions info;

    [SerializeField]
    private HTTPRequest req;
    [SerializeField]
    //private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //string json = "{\"fromId\":0,\"toId\":100,\"newId\":31,\"x\":10,\"z\":20,\"moveCount\":12}";
        //Debug.Log(json);
        //actions = BaseActions.Deserialize(json);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            req.GET("http://localhost:8080/moveGroup?number=" + info.number.ToString());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            string body = JsonUtility.ToJson(info);
            req.POST("http://localhost:8080/moveGroup", body);
        }
        if (req.result != null)
        {
            var res = JsonUtility.FromJson<BaseActions>(req.result);
            Debug.Log(JsonUtility.ToJson(res));
            req.result = null;
        }
    }
}
