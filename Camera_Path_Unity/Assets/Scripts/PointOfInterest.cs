using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour {

	private float areaOfInterestRadius;

	void Start() {
		areaOfInterestRadius = GetComponent<SphereCollider>().radius;
	}

	public float AreaOfInterestRadius() {
		return areaOfInterestRadius;
	}




}
