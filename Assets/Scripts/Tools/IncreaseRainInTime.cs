using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IncreaseRainInTime : MonoBehaviour {

    public float TimeToMaxRain = 100;

    private GameObject m_RainGO;
    private DigitalRuby.RainMaker.RainScript m_rainScript;
    private float m_timer = 0;

    // Use this for initialization
	void Start () {
        m_RainGO = this.gameObject;
        m_rainScript = m_RainGO.GetComponent<DigitalRuby.RainMaker.RainScript>();
	}
	
	// Update is called once per frame
	void Update () {
        m_timer += Time.deltaTime;
        m_rainScript.RainIntensity = Utils.Remap(m_timer, 0, TimeToMaxRain, 0, 1);        
	}
}
