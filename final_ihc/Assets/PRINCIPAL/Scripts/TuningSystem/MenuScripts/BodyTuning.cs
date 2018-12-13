using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTuning : MonoBehaviour {

	[System.Serializable] public class Cars
	{
		public string name;
		public GameObject[] Kits;
		public GameObject[] Spoilers;
		public GameObject[] Wheels;
	}

	public Cars[] CarList;

	private int CarSelected;
	private int KitSelected=0;
	private int SpoilerSelected=0;
	private int WheelsSelected=0;


	//__________________________GET CAR SELECTED__________________________________________________________________________________________
	public void SetCarSelected(int car){
		//get car selected
		CarSelected = car;
		//load and show the paint
		LoadBodyTuning();
	}
	//__________________________LOAD VOID________________________________________________________________________________________________
	//load and apply all paint value on car
	public void LoadBodyTuning(){
		//Load all value of the car selected
		KitSelected = PlayerPrefs.GetInt(CarSelected + "_BodyKit",0);
		SpoilerSelected = PlayerPrefs.GetInt(CarSelected + "_Spoiler",0);
		WheelsSelected = PlayerPrefs.GetInt(CarSelected + "_Wheels",0);

		//disable all parts and show only selected one
		//_______KITS________________________________________________________
		//disable all objects
		for (int i = 0; i < CarList[CarSelected].Kits.Length; i++) {
			CarList [CarSelected].Kits[i].SetActive (false);
		}
		//enable only selected object
		CarList [CarSelected].Kits[KitSelected].SetActive (true);
		//_______SPOILERS________________________________________________________
		//disable all objects
		for (int i = 0; i < CarList[CarSelected].Spoilers.Length; i++) {
			CarList [CarSelected].Spoilers[i].SetActive (false);
		}
		//enable only selected object
		CarList [CarSelected].Spoilers[SpoilerSelected].SetActive (true);
		//_______WHEELS________________________________________________________
		//disable all objects
		for (int i = 0; i < CarList[CarSelected].Wheels.Length; i++) {
			CarList [CarSelected].Wheels[i].SetActive (false);
		}
		//enable only selected object
		CarList [CarSelected].Wheels[WheelsSelected].SetActive (true);
	}

	//__________________________UI VOIDS________________________________________________________________________________________________
	//set body by UI
	public void SetKit(int kit){
		//Save kit installed on the car
		PlayerPrefs.SetInt(CarSelected + "_BodyKit",kit);
		//load values
		LoadBodyTuning();
	}
	//set spoiler by UI
	public void SetSpoiler(int spo){
		//Save kit installed on the car
		PlayerPrefs.SetInt(CarSelected + "_Spoiler",spo);
		//load values
		LoadBodyTuning();
	}
	//set wheel by UI
	public void SetWheels(int whe){
		//Save kit installed on the car
		PlayerPrefs.SetInt(CarSelected + "_Wheels",whe);
		//load values
		LoadBodyTuning();
	}
}
