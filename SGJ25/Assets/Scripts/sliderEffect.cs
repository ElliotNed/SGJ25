using UnityEngine;

public class sliderEffect : MonoBehaviour
{
    [SerializeField] int powerCapacity;

    [Range(0, 255)] int slider1;
    [Range(0, 255)] int slider2;
    [Range(0, 255)] int slider3;

    int sliderSum;

    private void Update()
    {
        sliderSum = slider1 + slider2 + slider3;
        if(sliderSum > powerCapacity)
        {
            
        }
    }
}
