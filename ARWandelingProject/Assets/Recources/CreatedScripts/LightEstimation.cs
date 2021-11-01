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

    private Light currentLight;

    void Awake()
    {
        currentLight.GetComponent<Light>();
        Invoke("MethodActive", 0.1f);
    }

    private void OnEnable()
    {
        Debug.Log("Enblabled");
        arCameraManager.frameReceived += FrameUpdated;
    }

    void MethodActive()
    {
        gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        Debug.Log("Disabled");
        arCameraManager.frameReceived -= FrameUpdated;
    }

    private void FrameUpdated(ARCameraFrameEventArgs args)
    {
        Debug.Log($"{gameObject.transform.position}");

        if (args.lightEstimation.averageBrightness.HasValue)
        {
            brightnessValue.text = $"Brightness: {args.lightEstimation.averageBrightness.Value}";
            currentLight.intensity = args.lightEstimation.averageBrightness.Value;
        }

        if (args.lightEstimation.averageColorTemperature.HasValue)
        {
            tempValue.text = $"Temp Color: {args.lightEstimation.averageColorTemperature.Value}";
            currentLight.colorTemperature = args.lightEstimation.averageColorTemperature.Value;
        }

        if (args.lightEstimation.colorCorrection.HasValue)
        {
            colorCorrectionValue.text = $"ColorCorrection: {args.lightEstimation.colorCorrection.Value}";
            currentLight.color = args.lightEstimation.colorCorrection.Value;
        }
    }
}
