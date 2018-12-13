using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapArrow : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		if(!target){ 
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		}
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.position.x, 70f, target.position.z);
		transform.rotation = Quaternion.Euler (0,target.rotation.eulerAngles.y + 180f, 0);
	}
}
