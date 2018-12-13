using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreCar : MonoBehaviour {

	public KeyCode Restore = KeyCode.R;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (Restore)) {
			transform.localRotation = Quaternion.Euler (transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 0);
		}
	}
}
