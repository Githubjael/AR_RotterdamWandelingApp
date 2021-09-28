using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class TestController : MonoBehaviour
{
    public async void TestGet()
    {
        var url = "";

        using var www = UnityWebRequest.Get(url);

        www.SetRequestHeader("Content-Type", "applicatio/json");

        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }
    }
}
