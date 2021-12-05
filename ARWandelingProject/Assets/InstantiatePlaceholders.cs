using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlaceholders : MonoBehaviour
{
    [SerializeField] private List<GameObject> Placeholder_Buildings = new List<GameObject>();
    [SerializeField] private List<float> latitude_Placeholder = new List<float>();
    [SerializeField] private List<float> longitude_Placeholder = new List<float>();
    public void Start()
    {
        for (var i = 0;i < 2;i++)
        {
            Vector3 xyz_vector = Quaternion.AngleAxis(longitude_Placeholder[i], -Vector3.up) * Quaternion.AngleAxis(latitude_Placeholder[i], -Vector3.right) * new Vector3(0, 0, 1);
            Instantiate<GameObject>(Placeholder_Buildings[i], xyz_vector, Quaternion.identity);
        }
    }
}
