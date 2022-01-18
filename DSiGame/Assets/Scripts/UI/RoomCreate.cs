using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCreate : MonoBehaviour
{
    private RoomStruct room = new RoomStruct();
    private bool isWait = false;

    [SerializeField] private Text number;
    [SerializeField] private HTTPRequest req;
    [SerializeField] private Button enterButton;
    [SerializeField] private GameObject WaitEnter;
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
            number.text = "•”‰®”Ô†:" + room.number.ToString();
            WaitEnter.SetActive(true);
            WaitEnter.GetComponent<WaitEnterRoom>().room=room;
            req.result = null;
        }
    }
    public void OnClick() {
        if (isWait == false)
        {
            req.GET("https://fishevolution.herokuapp.com/room/create");
            this.transform.GetChild(0).gameObject.GetComponent<Text>().text = "•åW‚ğ~‚ß‚é";
            enterButton.enabled = false;
        }
        else
        {
            req.DELETE("https://fishevolution.herokuapp.com/room?number="+room.number);
            this.transform.GetChild(0).gameObject.GetComponent<Text>().text = "•”‰®‚ğì‚é";
            enterButton.enabled = true;
            WaitEnter.SetActive(false);
        }
        isWait = !isWait;
    }
}