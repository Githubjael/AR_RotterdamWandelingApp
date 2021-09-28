using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class HappyHttpClient
{ 
    public async Task<TResultType> Get<TResultType>(string url)
    {
        using var www = UnityWebRequest.Get(url);

        www.SetRequestHeader("Content-Type", "applicatio/json");

        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        var jsonResponse = www.downloadHandler.text;

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Failed: {www.error}");
        }

        try
        {
            var result = JsonConvert.DeserializeObject<TResultType>(jsonResponse);
            Debug.Log($"Succes: {www.downloadHandler.text}");
            return result;
        }
        catch (Exception ex)
        {
            Debug.LogError($"{this} Could not parse {jsonResponse} .{ex.Message}");
            return default;
        }
    }
}
