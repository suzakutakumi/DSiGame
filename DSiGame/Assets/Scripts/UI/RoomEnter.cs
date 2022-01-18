using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomEnter : MonoBehaviour
{
    private RoomStruct room=new RoomStruct();
    [SerializeField] private Text number;
    [SerializeField] private HTTPRequest req;
    public void Start()
    {
        req.result = null;
    }
    public void Update()
    {
        if (req.result != null)
        {
            Debug.Log(req.result);
            room = RoomStruct.Deserialize(req.result);
            //changeScene(game);
            req.result = null;
        }
    }
    public void OnClick()
    {
        room.number=int.Parse(number.text);
        Debug.Log(JsonUtility.ToJson(room));
        req.POST("https://fishevolution.herokuapp.com/room/enter", JsonUtility.ToJson(room));
    }
}
