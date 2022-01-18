using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitEnterRoom : MonoBehaviour
{
    private float befTime=0;

    [SerializeField] private HTTPRequest req;

    public RoomStruct room;
    public void Start()
    {
        req.result = null;
    }
    public void Update()
    {
        befTime += Time.deltaTime;

        if (befTime >= 2)
        {
            req.GET("https://fishevolution.herokuapp.com/room/isStart?number="+room.number);
            befTime = -10000f;
        }
        if (req.result != null)
        {
            Debug.Log(req.result);
            var r=StartStruct.Deserialize(req.result);
            if (r.isStart)
            {
                Player.GameManager.room = room;
                SceneManager.LoadScene("PlayerMoveInMap");
            }
            req.result = null;
            befTime = 0f;
        }
    }
}