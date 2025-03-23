using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class sliderEffect : MonoBehaviour
{
    [SerializeField] SuperCollider.SuperCollider Sound; 
    [SerializeField] float maxPowerCapacity = 50;

    [SerializeField] Material shader;
  //  SimpleMessageTransmitter
    float powerCapacity;

    public UnityEngine.UI.Slider sliderThermal;
    public UnityEngine.UI.Slider sliderRadar;
    public UnityEngine.UI.Slider sliderOptic;

    public UnityEngine.UI.Toggle red;
    public UnityEngine.UI.Toggle green;
    public UnityEngine.UI.Toggle blue;

    private void Awake()
    {
        powerCapacity = maxPowerCapacity;
    }

    private void Start()
    {
       
        sliderThermal.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderThermal, "distortMul");  });
        sliderRadar.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderRadar, "distortAdd"); });
        sliderOptic.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderOptic, "lpf");  });
    }

    private void Update()
    {
        shader.SetFloat("_Slider_Thermic", sliderThermal.value);
        shader.SetFloat("_Slider_Radar", sliderRadar.value);
        shader.SetFloat("_Slider_Optic", sliderOptic.value);

        if (red)
            shader.SetInt("_R", 1);
        else
            shader.SetInt("_R", 0);
    }

    private void UpdateSlidersMaxValue(UnityEngine.UI.Slider slider, string msg)
    {
        //todo send msg
        float sum = sliderThermal.value + sliderRadar.value + sliderOptic.value;
        if(sum > maxPowerCapacity)
        {
            slider.value += maxPowerCapacity - sum;
        }
        //Sound.SendMsg("/music/set", msg, 1 + slider.value);
    }
}