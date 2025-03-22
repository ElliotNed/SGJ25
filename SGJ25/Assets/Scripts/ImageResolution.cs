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

    [UnityEngine.Range(0,2)]
    public int resIndex = 0;

    private void Update()
    {
        ChangeRes(resIndex);
    }

    private void ChangeRes(int x)
    {
        cam.targetTexture = resolutionList[resIndex];
        mapScreenUI.texture = resolutionList[resIndex];
    }
}