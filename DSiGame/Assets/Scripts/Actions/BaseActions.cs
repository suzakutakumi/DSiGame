using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BaseActions
{
    public int fromId=0;   //影響を与える側の群ID
    public int toId = 0;   //影響を受ける側の群ID
    public int newId = 0;  //新規群を作成する際に用いるID
    public int x = 0, z = 0;   //int型の座標
    public int moveCount = 0;  //移動させる群れ

    public static BaseActions Deserialize(string json)
    {
        BaseActions user = JsonUtility.FromJson<BaseActions>(json);
        return user;
    }
}
