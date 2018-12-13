using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class LoaderPerformanceTuning : MonoBehaviour {

	[Tooltip ("The Car Number in the Body Tuning script array")]
	public int CarNumber = 0;
	//in this case I am using Unity Standard Assets Car Controller. if you use another car controller you must change this row of code in accord with your CC
	public CarController CarControllerScript;
	public CarAudio CarAudioScript;

	[Header("Engine:")]
	[Tooltip ("The torque to ADD to the car controller. The array must have lenght equal to the performance stage available!")]
	public int[] Torque;
	[Tooltip ("The max speed to ADD to the car controller. The array must have lenght equal to the performance stage available!")]
	public int[] MaxSpeed;
	[Tooltip ("The pitch to ADD to the car controller. The array must have lenght equal to the performance stage available!")]
	public float[] Pitch;
	[Header("Brake:")]
	[Tooltip ("The Brake torque to ADD to the car controller. The array must have lenght equal to the performance stage available!")]
	public int[] Brake;

	// Use this for initialization
	void Start () {
		//get Car Controller component (ex: if you use another car controller you must change this row of code in accord with your CC)
		if(!CarControllerScript) gameObject.GetComponent<CarController>();
		if(!CarAudioScript) gameObject.GetComponent<CarAudio>();

		//load and set all values
		//ENGINE:
		CarControllerScript.m_Topspeed += MaxSpeed[PlayerPrefs.GetInt(CarNumber + "_PerformanceStage",0)];
		CarControllerScript.m_FullTorqueOverAllWheels += Torque[PlayerPrefs.GetInt(CarNumber + "_PerformanceStage",0)];
		CarAudioScript.pitchMultiplier += Pitch[PlayerPrefs.GetInt(CarNumber + "_PerformanceStage",0)];
		//BRAKE:
		CarControllerScript.m_BrakeTorque += Brake[PlayerPrefs.GetInt(CarNumber + "_PerformanceStage",0)];

	}
}
