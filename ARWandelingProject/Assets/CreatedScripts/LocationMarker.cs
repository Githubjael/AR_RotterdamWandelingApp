using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationMarker : MonoBehaviour
{
    // Start is called before the first frame update
    public TestLocCoordObjectPlacement TLCOP;
    public Vector2 LatLon;
    public GameObject SmallHouse6Building;
    void Start()
    {
        SmallHouse6Building = GameObject.Find("Small House 6");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
