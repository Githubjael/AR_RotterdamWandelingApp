using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public class JsonSerializationOption : ISerializationOption
{
    public string ContentType => "application/json";

    public T Deserialize<T>(string text)
    {
        try
        {
            var result = JsonConvert.DeserializeObject<List<T>>(text);
            Debug.Log($"Succes: {text}");
            return default;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Could not parse {text} .{ex.Message}");
            return default;
        }
    }
}
