using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class LightEstimation : MonoBehaviour
{
    [SerializeField]
    private ARCameraManager arCameraManager;

    [SerializeField]
    private TextMeshProUGUI brightnessValue;
    [SerializeField]
    private TextMeshProUGUI tempValue;
    [SerializeField]
    private TextMeshProUGUI colorCorrectionValue;
}
