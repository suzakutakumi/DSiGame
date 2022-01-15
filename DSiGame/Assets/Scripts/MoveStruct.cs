using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveStruct
{
    public int number;
    public int playerId;
    public bool isMove;
    public int groupId;
    public int x;
    public int y;
    public static MoveStruct Deserialize(string json)
    {
        MoveStruct user = JsonUtility.FromJson<MoveStruct>(json);
        return user;
    }
}
