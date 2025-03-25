using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

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
    public UnityEngine.UI.Slider sliderRes;

    public UnityEngine.UI.Toggle red;
    public UnityEngine.UI.Toggle green;
    public UnityEngine.UI.Toggle blue;

    public TextMeshProUGUI EnergieValueText;

    private void Awake()
    {
        powerCapacity = maxPowerCapacity;
    }

    private void Start()
    {
       
        sliderThermal.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderThermal, "distortMul");  });
        sliderRadar.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderRadar, "distortAdd"); });
        sliderOptic.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderOptic, "lpf");  });
        sliderRes.onValueChanged.AddListener(delegate { UpdateSlidersMaxValue(sliderRes); });

        RedToggle(true);
        GreenToggle(true);
        BleuToggle(true);
    }

    private void Update()
    {
        shader.SetFloat("_Slider_Thermic", sliderThermal.value);
        shader.SetFloat("_Slider_Radar", sliderRadar.value);
        shader.SetFloat("_Slider_Optic", sliderOptic.value);

        EnergieValueText.text  = EngergieCalculation().ToString() + "/" + maxPowerCapacity;
    }

    public float EngergieCalculation()
    {
        return (int)(maxPowerCapacity - sliderThermal.value - sliderRadar.value - sliderOptic.value - sliderRes.value*10);
    }

    public void RedToggle(bool tog)
    {
        if (tog)
        {
            shader.SetInt("_R", 1);
        }
        else
            shader.SetInt("_R", 0);
    }public void GreenToggle(bool tog)
    {
        if (tog)
        {
            shader.SetInt("_G", 1);
        }
        else
            shader.SetInt("_G", 0);
    }public void BleuToggle(bool tog)
    {
        if (tog)
        {
            shader.SetInt("_B", 1);
        }
        else
            shader.SetInt("_B", 0);
    }

    private void UpdateSlidersMaxValue(UnityEngine.UI.Slider slider, string msg = null)
    {
        //todo send msg
        float sum = sliderThermal.value + sliderRadar.value + sliderOptic.value + (sliderRes.value*10);
        if(sum > maxPowerCapacity)
        {
            float excess = maxPowerCapacity - sum;
            if (slider == sliderRes)
                slider.value += excess/10;
            else
                slider.value += excess;
        }
        if(msg != null)
            Sound.SendMsg("/music/set", msg, 1 + slider.value);
    }
}