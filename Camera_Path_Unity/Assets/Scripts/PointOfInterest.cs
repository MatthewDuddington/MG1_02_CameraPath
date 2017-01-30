using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour {

	private float areaOfInterestRadius;

	void Start() {
		areaOfInterestRadius = 0.5f * transform.lossyScale.x;
	}

	public float AreaOfInterestRadius() {
		return areaOfInterestRadius;
	}




}
