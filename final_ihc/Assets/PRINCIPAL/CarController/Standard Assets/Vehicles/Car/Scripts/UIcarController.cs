using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class UIcarController : MonoBehaviour {

	public CarController controller;

	public Text Speed;
	public Text Gear;
	public Image RPM;

	public bool ChangeColorRPM = true;
	public Color RPMdefault = Color.blue;
	public Color RPMover = Color.red;

	void Start(){
		if(!controller){ 
			GameObject obj = GameObject.FindGameObjectWithTag ("Player");
			controller = obj.GetComponent<CarController> ();
		}
	}
	// Update is called once per frame
	void Update () {
		Speed.text = Mathf.Round(controller.CurrentSpeed).ToString ();

		RPM.fillAmount = Mathf.Clamp (controller.Revs * 0.7f, 0.2f, 0.63f);
		//RPM bar color
		{
			if (ChangeColorRPM && controller.Revs * 0.7f > 0.6f)
				RPM.color = RPMover;
			else RPM.color = RPMdefault;
		}

		//gear
		{
			if (!controller.IsReversed) {
				Gear.text = (controller.m_GearNum +1).ToString ();
			}
			else Gear.text = "R";
		}
	}
}
