using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class ReverseLight : MonoBehaviour {

	public CarController car; // reference to the car controller, must be dragged in inspector

	public GameObject ReverseObj;

	// Update is called once per frame
	void Update () {
		// enable the Renderer when the car is braking, disable it otherwise.
		ReverseObj.SetActive (car.IsReversed);
	}
}
