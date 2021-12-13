using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLight : MonoBehaviour
{
   
    float minIntensity = 1f;
    [SerializeField]float currentIntensity;
    [SerializeField] float value;

    bool ligtIncreaseState;
    bool ligtDecreaseState;

    Light light;
    // Start is called before the first frame update
    void Start()
    {
        ligtIncreaseState = true;
        light = GetComponent<Light>();
        light.intensity = currentIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = currentIntensity;

        if(currentIntensity <= minIntensity && ligtIncreaseState == true)
        {
          
            LightIntensityPlus(value);
        }
        if( currentIntensity >= minIntensity && ligtIncreaseState == true)
        {
            ligtIncreaseState = false;
        }
        if(ligtIncreaseState == false)
        {
            LightIntensityMinus(value);
            if(currentIntensity <= 0)
            {
                ligtIncreaseState = true;
            }
        }
   
        Debug.Log(ligtIncreaseState);
    }

    void LightIntensityPlus(float level)
    {
        
        currentIntensity += level * Time.deltaTime;
    }
    void LightIntensityMinus(float level)
    {
        
        currentIntensity -= level * Time.deltaTime;
    }

}
