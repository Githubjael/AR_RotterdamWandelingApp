using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISerializationOption
{
    T Deserialize<T>(string text);
}
