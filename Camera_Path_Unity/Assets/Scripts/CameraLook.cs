using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

    public PointOfInterest[] pois;
    public int poi_ID = 0;
    public GameObject PoIBlob;
    
    private Curve cushioningCurve;

	// Use this for initialization
	void Start () {
		
		//cushioningCurve = new HermitCurve(Vector3.zero, new Vector3(1,1,0), new Vector3(2f,0,0), new Vector3(-3f,0,0));
		//cushioningCurve.DrawDebugCurve(0.1f, 100);
	}
	
	// Update is called once per frame
	void Update () {

		// Check for camera being close enough to recieve rotation influence from each point of interest
		float[] weights = new float[pois.Length];
		for (int i = 0; i < pois.Length; i++) {
			float distanceFromPoI = Vector3.Magnitude(pois[i].transform.position - transform.position);
			// print (distanceFromPoI);
			if (distanceFromPoI <= pois[i].AreaOfInterestRadius()) {
				float weight = distanceFromPoI / pois[i].AreaOfInterestRadius();
				// Use Hermet cuve Y value to 'cushion' the approach and exit from PoIs
				weight = R_Curve.hermit(Vector3.zero, new Vector3(1,1,0), new Vector3(2f,0,0), new Vector3(-3f,0,0), weight).y;
				weight = 1 - weight;
				weights[i] = weight;
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
