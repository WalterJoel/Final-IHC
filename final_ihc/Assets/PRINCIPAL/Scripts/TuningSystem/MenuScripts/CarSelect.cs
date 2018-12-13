using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelect : MonoBehaviour {

	[System.Serializable] public class Cars
	{
		public string name;
		public GameObject CarMesh;
	}

	public Cars[] carList;

	[Header("Tuning Scripts:")]
	public PaintTuning Paint;
	public BodyTuning Body;
	public PerformancesTuning Performance;

	void Start(){
		//load car to spawn and spawn it
		UpdateCarSelected (PlayerPrefs.GetInt("CarSelected",0));
	}

	//update screen show only car selected
	void UpdateCarSelected(int CarSelected){
		//disable all objects
		for (int i = 0; i < carList.Length; i++) {
			carList [i].CarMesh.SetActive (false);
		}
		//enable only selected object
		carList [CarSelected].CarMesh.SetActive (true);
		//save car selected
		PlayerPrefs.SetInt("CarSelected",CarSelected);

		//say to all scripts that car is changed
		if(Paint) Paint.SetCarSelected(CarSelected);
		if(Body) Body.SetCarSelected(CarSelected);
		if(Performance) Performance.SetCarSelected(CarSelected);
	}

	//select car bu ui
	public void SelectCar(int i){
		UpdateCarSelected (i);
	}
}
