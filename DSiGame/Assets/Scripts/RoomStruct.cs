using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomStruct
{
    public int number=0;
    public bool isFirst=false;
    public static RoomStruct Deserialize(string json)
    {
        RoomStruct room = JsonUtility.FromJson<RoomStruct>(json);
        return room;
    }
}
