using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public int progress = 0;
    // Start is called before the first frame update
    void Start()
    {
        slider.interactable = false;
    }

   
    public void UpdateProgress()    
    {
        progress++;
        slider.value = progress;
    }
    public void RemoveProgress()
    {
        progress--;
        if(progress < 0)
        {
            progress = 0;
        }

        slider.value = progress;
    }
}
