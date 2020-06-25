using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomIlsandHandling : MonoBehaviour
{
    public GameObject water;
    public GameObject windowsWater;
    public GameObject light;
    public GameObject windowsLight;

    public Material skybox;
    public Material windowsSkybox;

    void OnEnable()
    {
        water.SetActive(false);
        windowsWater.SetActive(true);
        light.SetActive(false);
        windowsLight.SetActive(true);
        RenderSettings.skybox = windowsSkybox;

    }

    void OnDisable()
    {
        water.SetActive(true);
        windowsWater.SetActive(false);
        light.SetActive(true);
        windowsLight.SetActive(false);
        RenderSettings.skybox = skybox;
    }
}
