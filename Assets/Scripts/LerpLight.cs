﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpLight : MonoBehaviour {

	public float startIntensity;
	public float endIntensity;
	public float lerpDuration;
	float lerpVal;
	public Light lightToModify;


	bool isLerping;

	public void StartLerp()
	{
		isLerping = true;
		lerpVal = 0;
	}
	// Use this for initialization
	void Start () {
		lightToModify = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isLerping) {
			lerpVal += Time.deltaTime;
			lightToModify.intensity = endIntensity * lerpVal/lerpDuration;
			if (lerpVal/lerpDuration > 1) {
				lerpVal = 0;
				isLerping = false;
			}
		}
	}
}