using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

    public PointOfInterest[] pois;
    public int poi_ID = 0;
    public GameObject PoIBlob;

    public int timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

//       if(timer == 299){
//        pOfI_ID++;
//       }
//
//       transform.LookAt(pOfI[pOfI_ID].transform);
//       timer++;
//       timer = timer % 300;



		// Check for camera being close enough to recieve rotation influence from each point of interest
		float[] weights = new float[pois.Length];
		for (int i = 0; i < pois.Length; i++) {
			float distanceFromPoI = Vector3.Magnitude(pois[i].transform.position - transform.position);
			print (distanceFromPoI);
			if (distanceFromPoI <= pois[i].AreaOfInterestRadius()) {
				weights[i] = 1 - (distanceFromPoI / pois[i].AreaOfInterestRadius());
			}
			else {
				weights[i] = 0;
			}
		}

		// Get the total amount of influence being cast upon the camera
		float weightTotal = 0;
		foreach (float weight in weights) {
			weightTotal += weight;
		}

		// Normalise the weights
		for (int i = 0; i < weights.Length; i++) {
			weights[i] = weights[i] / weightTotal;
		}

		// Create compound Vector3 to look at
		Vector3 compoundPoI = new Vector3();
		for (int i = 0; i < pois.Length; i++) {
			compoundPoI += pois[i].transform.position * weights[i];
		}

		// Look at the compound point
		PoIBlob.transform.position = compoundPoI;
		transform.LookAt(compoundPoI);

    }



}
