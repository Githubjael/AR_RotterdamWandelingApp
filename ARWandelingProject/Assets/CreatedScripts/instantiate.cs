using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    public GameObject House1;
    public GameObject House2;
    public GameObject House3;
    public GameObject House4;
    public GameObject House4a;
    public GameObject House5;
    public GameObject House6;
    public GameObject House7;
    public GameObject House8;
    public GameObject House9;
    public GameObject House10;
    private void Awake()
    {
        Instantiate(House1, new Vector3(Random.Range(0, 11), -1, Random.Range(0, 5)), Quaternion.identity);
        Instantiate(House2, new Vector3(Random.Range(0, 11), -1, Random.Range(0, 5)), Quaternion.identity);
        Instantiate(House3, new Vector3(Random.Range(0, 11), -1, Random.Range(0, 5)), Quaternion.identity);
        Instantiate(House4, new Vector3(Random.Range(0, 11), -1, Random.Range(0, 5)), Quaternion.identity);
        Instantiate(House4a, new Vector3(Random.Range(0, 11), -1, Random.Range(0, 5)), Quaternion.identity);
        Instantiate(House5, new Vector3(Random.Range(0, 11), -1, Random.Range(0, 5)), Quaternion.identity);
        Instantiate(House6, new Vector3(Random.Range(0, 11), -1, Random.Range(0, 5)), Quaternion.identity);
        Instantiate(House7, new Vector3(Random.Range(0, 11), -1, Random.Range(0, 5)), Quaternion.identity);
        Instantiate(House8, new Vector3(Random.Range(0, 11), -1, Random.Range(0, 5)), Quaternion.identity);
        Instantiate(House9, new Vector3(Random.Range(0, 11), -1, Random.Range(0, 5)), Quaternion.identity);
        Instantiate(House10, new Vector3(Random.Range(0, 11), -1, Random.Range(0, 5)), Quaternion.identity);
    }
}
