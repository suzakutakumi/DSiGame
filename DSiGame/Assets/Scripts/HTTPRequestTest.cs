using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTTPRequestTest : MonoBehaviour
{
    [SerializeField]
    private HTTPRequest req;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            req.GET("https://google.com");
        }
        if (req.result != null)
        {
            Debug.Log(req.result);
            req.result = null;
        }
    }
}
