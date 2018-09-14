using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : LevelBase {

    public GameObject Podea;
    public GameObject PodeaCollider;

    // Use this for initialization
    void Start () {
        MessageManager.AddListener(Messages.Level2_FloorOn, TurnFloorOn);
	}

    // Update is called once per frame
    void Update () {
		
	}
    public void TurnFloorOn()
    {
        Podea.SetActive(true);
        PodeaCollider.SetActive(true);
    }
}
