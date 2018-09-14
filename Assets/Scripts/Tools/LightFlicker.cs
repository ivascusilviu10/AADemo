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
    [Tooltip("This works only for random flicker mode")]
    public float FlickerFrequency = 5;
    [Tooltip("This works only for random flicker mode")]
    public float FlickerDuration = 0.5f;
    public enum Mode
    {
        Random,
        Sine
    };
    //PRIVATES
    private float m_FlickerOffTimer = 0;
    private float m_FlickerOnTimer = 0;
    private Light m_thisLight;
    private bool m_IsLightFlickering = false;
    // Use this for initialization
    void Start()
    {
        m_thisLight = GetComponent<Light>();
        m_FlickerOffTimer = FlickerFrequency;
        m_FlickerOnTimer = FlickerDuration;

    }

    // Update is called once per frame
    void Update()
    {
        float LightValue = 0;
        switch (FlickerMode)
        {
            case Mode.Random:
                if (!m_IsLightFlickering)
                {
                    m_FlickerOffTimer -= Time.deltaTime; 
                }
                else
                {
                    m_FlickerOnTimer -= Time.deltaTime;
                }                
                if (m_FlickerOffTimer <= 0)
                {
                    m_IsLightFlickering = true; 
                    m_FlickerOffTimer = FlickerDuration;
                    LightValue = UnityEngine.Random.Range(MinValue, MaxValue);
                }
                if (m_FlickerOnTimer <= 0)
                {
                    LightValue = MinValue;
                }
                break;
            case Mode.Sine:
                LightValue = Utils.Remap(Mathf.Sin(Time.time) * 0.5f + 0.5f, 0, 1, MinValue, MaxValue);
                break;
            default:
                break;
        }
        m_thisLight.intensity = LightValue;
    }


}
