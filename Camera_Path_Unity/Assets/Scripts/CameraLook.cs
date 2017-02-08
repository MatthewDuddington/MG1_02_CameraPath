using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

    public PointOfInterest[] pois;
    public int poi_ID = 0;
    public GameObject PoIBlob;
    
    private Curve cushioningCurve;

    private bool onlyOnePoI = true;
    private Vector3 imagineryPoI;

	// Use this for initialization
	void Start () {
		
//		cushioningCurve = new HermitCurve(Vector3.zero, new Vector3(1,1f,0), new Vector3(3f,-0.5f,0), new Vector3(-3f,0.5f,0));
//		cushioningCurve.DrawDebugCurve(0.1f, 100);
	}
	
	// Update is called once per frame
	void Update () {

		// Check for camera being close enough to recieve rotation influence from each point of interest
		float[] weights = new float[pois.Length + 1];  // Extra space for balancing weight
		weights[weights.Length - 1] = 0;  // Default the extra to 0 so it only influences if we need it
		int weightCount = 0;

		for (int i = 0; i < weights.Length - 1; i++) {
			float distanceFromPoI = Vector3.Magnitude(pois[i].transform.position - transform.position);

			if (distanceFromPoI <= pois[i].AreaOfInterestRadius()) {
				weightCount++;
				float weight = distanceFromPoI / pois[i].AreaOfInterestRadius();
				// Use Hermet cuve Y value to 'cushion' the approach and exit from PoIs
				weight = R_Curve.hermit(Vector3.zero, new Vector3(1,1,0), new Vector3(3f,0,0), new Vector3(-3f,0,0), weight).y;
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

//		if (weightCount == 1) {
//			if (onlyOnePoI == false) {
//				onlyOnePoI = true;
//				imagineryPoI = PoIBlob.transform.position;
//			}
//			else {
//				onlyOnePoI = false;
//			}
//
//			weights[weights.Length - 1] = weightTotal;
//			weightTotal += weightTotal;	
//		}

		// Normalise the weights
		for (int i = 0; i < weights.Length; i++) {
			weights[i] = weights[i] / weightTotal;
		}

		// Create compound Vector3 to look at
		Mathd.Vector3 compoundPoI = Mathd.Vector3.zero;
		for (int i = 0; i < pois.Length; i++) {
			compoundPoI += new Mathd.Vector3(pois[i].transform.position * weights[i]);
		}

		// Look at the compound point
		PoIBlob.transform.position = compoundPoI.toUnityVec3;
		LookAt(compoundPoI);
    }

//    IEnumerator RemoveImagineryInfluence() {
//    	float timeToEnd = Time.time + 2.5f; // Disolve influence over 2.5sec
//    	Vector2 
//    	while (Time.time < timeToEnd) {
//    		Vector2.Lerp(
//    	}
//    }

    void LookAt(Mathd.Vector3 pointToLookAt) {
    	Mathd.Vector3 lookAtVector = pointToLookAt - new Mathd.Vector3(transform.position);
    	float angleBetweenVectors = Vector3.Dot(transform.right.normalized, lookAtVector.toUnityVec3);
    	transform.Rotate(transform.up, angleBetweenVectors);

    	//transform.rotation = new UnityEngine.Quaternion();
    }


}
