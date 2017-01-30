using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

    public GameObject[] pOfI;
    public int pOfI_ID = 0;

    public int timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       if(timer == 299){
        pOfI_ID++;
       }

       transform.LookAt(pOfI[pOfI_ID].transform);
       timer++;
       timer = timer % 300;
    }
}
