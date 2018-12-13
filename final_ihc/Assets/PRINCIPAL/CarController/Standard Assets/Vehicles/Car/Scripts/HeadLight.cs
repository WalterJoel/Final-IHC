using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLight : MonoBehaviour {

	public GameObject HeadLightOBJ;

	private bool isOn = false;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.L)) isOn = !isOn;

		HeadLightOBJ.SetActive (isOn);
	}
}
