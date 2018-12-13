using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarSpawn : MonoBehaviour {

	public GameObject[] Cars;

	public int CarToSpawn=0;

	// Use this for initialization
	void Start () {
		//load car to spawn
		CarToSpawn = PlayerPrefs.GetInt("CarSelected",0);
		//spawn car
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
		GameObject car = Instantiate (Cars [CarToSpawn], position, rotation);

		//update Ui car elements script, it is necessary to update rpm and so on...
		GameObject obj = FindObjectOfType<UIcarController>().gameObject;
		obj.GetComponent<UIcarController> ().controller = car.GetComponent<CarController>();

		//update minimap script. it is usefull for mini map camera
		GameObject minimapCam = FindObjectOfType<MiniMapCamera>().gameObject;
		minimapCam.GetComponent<MiniMapCamera> ().target = car.transform;
	}
}
