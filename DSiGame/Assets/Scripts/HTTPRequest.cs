using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class HTTPRequest:MonoBehaviour
{
    public string result=null;
    public void GET(string url)
    {
        StartCoroutine(GETCoroutine(url));
    }
    private IEnumerator GETCoroutine(string url)
    {
        UnityWebRequest req = UnityWebRequest.Get(url);
        yield return req.SendWebRequest();
        if (req.isNetworkError)
        {
            result = req.error;
        }
        else if (req.isHttpError)
        {
            result = req.error;
        }
        else
        {
            result = req.downloadHandler.text;
        }
    }
}
