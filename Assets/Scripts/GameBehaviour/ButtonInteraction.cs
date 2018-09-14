using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInteraction : MonoBehaviour {

    private bool _m_isPlayerInside = false;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (_m_isPlayerInside && Input.GetButton("Interact"))
        {
            MessageManager.Broadcast(Messages.Level2_FloorOn); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            _m_isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _m_isPlayerInside = false;
        }
    }

}
