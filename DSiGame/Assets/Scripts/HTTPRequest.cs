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
    public void POST(string url,string body)
    {
        StartCoroutine(POSTCoroutine(url,body));
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

    private IEnumerator POSTCoroutine(string url,string body)
    {
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(body);
        var req = new UnityWebRequest(url, "POST");
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        yield return req.SendWebRequest();
        if (req.isNetworkError)
        {
            result = req.error;
        }
        else if (req.isHttpError)
        {
            result = req.error;
        }
    }
}
