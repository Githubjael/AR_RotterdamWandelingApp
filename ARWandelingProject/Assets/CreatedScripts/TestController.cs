using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class TestController : MonoBehaviour
{
    [ContextMenu("Test Get")]
    public async void TestGet()
    {
        var url = "https://jsonplaceholder.typicode.com/todos/1";

        using var www = UnityWebRequest.Get(url);

        www.SetRequestHeader("Content-Type", "applicatio/json");

        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        var jsonResponse = www.downloadHandler.text;

        if(www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Succes: {www.downloadHandler.text}");
        }
        else
        {
            Debug.Log($"Failed: {www.error}");
        }

        try
        {

        }
        catch(Exception ex)
        {

        }
    }
}
