using NUnit.Framework;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ImageResolution : MonoBehaviour
{
    
    [SerializeField] List<RenderTexture> resolutionList = new List<RenderTexture>();

    [SerializeField] Camera cam;
    [SerializeField] RawImage mapScreenUI;

    [UnityEngine.Range(0,6)]
    public int resIndex = 0;

    public Slider sliderRes;

    private void Update()
    {
        sliderRes.onValueChanged.AddListener(delegate { ChangeRes((int)sliderRes.value); });
    }

    private void ChangeRes(int x)
    {
        cam.targetTexture = resolutionList[x];
        mapScreenUI.texture = resolutionList[x];
    }
}