using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageCameraController : MonoBehaviour {

	public float Sensitivity = 1f;
	float yDeg, xDeg;

	// Update is called once per frame
	void Update () {
		//press mouse wheel
		if (Input.GetMouseButton (2)) {
			yDeg += Input.GetAxis ("Mouse X") * -Sensitivity;

			xDeg += Input.GetAxis ("Mouse Y") * Sensitivity;
			xDeg = Mathf.Clamp (xDeg, 0f, 90f);

			transform.rotation = Quaternion.Euler (xDeg, yDeg, 0f); 
		}
	}
}
