using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAction : MonoBehaviour
{
    [SerializeField]
    public BaseActions actions;

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
        
    }
}
