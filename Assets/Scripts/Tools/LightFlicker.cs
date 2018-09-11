using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightFlicker : MonoBehaviour
{

    //PUBLICS
    public Mode FlickerMode = LightFlicker.Mode.Random;
    public float MinValue = 0.1f;
    public float MaxValue = 2;
    //PRIVATES
    public enum Mode
    {
        Random,
        Sine
    };
    private Light m_thisLight;
    // Use this for initialization
    void Start()
    {
        m_thisLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float LightValue = 0;
        switch (FlickerMode)
        {
            case Mode.Random:
                LightValue = UnityEngine.Random.Range(MinValue, MaxValue);
                break;
            case Mode.Sine:
                LightValue = Utils.Remap(Mathf.Sin(Time.time) * 0.5f + 0.5f,0,1,MinValue,MaxValue);
                break;
            default:
                break;
        }
        m_thisLight.intensity = LightValue;
    }

    
}
