using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformancesTuning : MonoBehaviour {

	private int CarSelected;

	//__________________________GET CAR SELECTED__________________________________________________________________________________________
	public void SetCarSelected(int car){
		//get car selected
		CarSelected = car;
	}

	//__________________________UI VOIDS________________________________________________________________________________________________
	//set performaces by UI
	public void SetPerformance(int perf){
		//save the paint color
		PlayerPrefs.SetInt(CarSelected + "_PerformanceStage",perf);
	}
}
