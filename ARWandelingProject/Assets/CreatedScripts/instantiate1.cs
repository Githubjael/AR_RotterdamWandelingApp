using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate1 : MonoBehaviour
{
    public GameObject house;
    private void Awake()
    {
        var i = 0;
        while (i < 50)
        {
            Instantiate(house, new Vector3(Random.Range(0, 15), -2 , Random.Range(0, 10)), Quaternion.identity);
            i++;
        }
    }
}
