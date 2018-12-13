using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour {

	public Transform target;
	public float rotation = 90f;

	// Use this for initialization
	void Start () {
		if(!target){ 
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.position.x, 80f, target.position.z);
		transform.rotation = Quaternion.Euler (rotation,target.rotation.eulerAngles.y, 0);
	}
}
