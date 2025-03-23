using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class sliderEffect : MonoBehaviour
{
    [SerializeField] SuperCollider.SuperCollider Sound; 
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
        sliderThermal.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderThermal, "distortMul");  });
        sliderRadar.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderRadar, "distortAdd"); });
        sliderOptic.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderOptic, "lpf");  });
    }

    private void UpdateSlidersMaxValue(UnityEngine.UI.Slider slider, string msg)
    {
        //todo send msg
        float sum = sliderThermal.value + sliderRadar.value + sliderOptic.value;
        if(sum > maxPowerCapacity)
        {
            slider.value += maxPowerCapacity - sum;
        }
        Sound.SendMsg("/music/set", msg, 1 + slider.value);
    }
}