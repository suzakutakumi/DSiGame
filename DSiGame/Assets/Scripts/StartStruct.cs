using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StartStruct
{
    public bool isStart;
    public static StartStruct Deserialize(string json)
    {
        StartStruct start = JsonUtility.FromJson<StartStruct>(json);
        return start;
    }
}
