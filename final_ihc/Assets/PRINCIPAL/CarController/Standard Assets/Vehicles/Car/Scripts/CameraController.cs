using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject BackCamera;
	public GameObject FrontCamera;
	
	// Update is called once per frame
	void Update () {
		BackCamera.SetActive (!Input.GetKey (KeyCode.B));
		FrontCamera.SetActive (Input.GetKey (KeyCode.B));
	}
}
