using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class TestAction : MonoBehaviour
{
    public BaseActions info = new BaseActions();

    [SerializeField]
    private HTTPRequest req;
    [SerializeField]
    private ActionManager _actionManager;

    // Start is called before the first frame update
    void Start()
    {
        req.result = null;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("FirstUpdate");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            req.GET("https://fishevolution.herokuapp.com/action?number=" + info.number.ToString());
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            string body = JsonUtility.ToJson(info);
            req.POST("https://fishevolution.herokuapp.com/action", body);
        }
        if (req.result != null)
        {
            //var res = JsonUtility.FromJson<BaseActions>(req.result);
            BaseActions res = new BaseActions();
            res.fromId = 0;
            res.toId = 0;
            res.moveCount = 150;
            res.whatAction = "attack";
            Debug.Log(JsonUtility.ToJson(res));

            _actionManager.getID(res.fromId, res.toId);
            switch (res.whatAction)
            {
                case "attack":
                    _actionManager.Attack();
                    req.result = null;
                    break;
                case "exchange":
                    _actionManager.Exchange(res.moveCount);
                    req.result = null;
                    break;
                case "create":
                    _actionManager.Create(res.moveCount);
                    req.result = null;
                    break;
                case "evolution":
                    _actionManager.Evolution();
                    req.result = null;
                    break;
                case "noAction":
                    //_actionManager.NoAction();
                    req.result = null;
                    break;
                default:
                    req.result = null;
                    break;
            }
        }
    }
}
