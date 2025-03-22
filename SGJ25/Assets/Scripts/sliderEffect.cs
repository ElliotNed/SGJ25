using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class sliderEffect : MonoBehaviour
{
    [SerializeField] float maxPowerCapacity = 50;
  //  SimpleMessageTransmitter
    float powerCapacity;

    public UnityEngine.UI.Slider sliderThermal;
    public UnityEngine.UI.Slider sliderRadar;
    public UnityEngine.UI.Slider sliderOptic;

    private void Awake()
    {
        powerCapacity = maxPowerCapacity;
    }

    private void Start()
    {
        sliderThermal.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderThermal); });
        sliderRadar.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderRadar); });
        sliderOptic.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderOptic); });
    }

    private void UpdateSlidersMaxValue(UnityEngine.UI.Slider slider)
    {
        //todo send msg
        float sum = sliderThermal.value + sliderRadar.value + sliderOptic.value;
        if(sum > maxPowerCapacity)
        {
            slider.value += maxPowerCapacity - sum;
        }
    }
}