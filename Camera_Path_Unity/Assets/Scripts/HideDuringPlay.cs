﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDuringPlay : MonoBehaviour {

	void Start () {
		GetComponent<MeshRenderer>().enabled = false;
	}

}
