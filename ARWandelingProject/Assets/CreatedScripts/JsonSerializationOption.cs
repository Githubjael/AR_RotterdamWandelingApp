using Newtonsoft.Json;
using System;
using UnityEngine;

public class JsonSerializationOption : ISerializationOption
{
    public T Deserialize<T>(string text)
    {
        try
        {
            var result = JsonConvert.DeserializeObject<T>(text);
            Debug.Log($"Succes: {text}");
            return result;
        }
        catch (Exception ex)
        {
            Debug.LogError($"{this} Could not parse {text} .{ex.Message}");
            return default;
        }
    }
}
