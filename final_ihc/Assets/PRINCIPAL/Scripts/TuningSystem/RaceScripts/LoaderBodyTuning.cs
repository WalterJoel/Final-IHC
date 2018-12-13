using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderBodyTuning : MonoBehaviour {

	[Tooltip ("The Car Number in the Body Tuning script array")]
	public int CarNumber = 0;
	[Header("Tuning:")]
	public GameObject[] Kits;
	public GameObject[] Spoilers;
	[Header("Wheels:")]
	public GameObject[] WheelFR;
	public GameObject[] WheelFL;
	public GameObject[] WheelRR;
	public GameObject[] WheelRL;

	private int KitSelected=0;
	private int SpoilerSelected=0;
	private int WheelsSelected=0;

	// Use this for initialization
	void Start () {
		//Load all value of the car selected
		KitSelected = PlayerPrefs.GetInt(CarNumber + "_BodyKit",0);
		SpoilerSelected = PlayerPrefs.GetInt(CarNumber + "_Spoiler",0);
		WheelsSelected = PlayerPrefs.GetInt(CarNumber + "_Wheels",0);

		//disable all parts and show only selected one
		//_______KITS________________________________________________________
		//disable all objects
		for (int i = 0; i < Kits.Length; i++) {
			Kits[i].SetActive (false);
		}
		//enable only selected object
		Kits[KitSelected].SetActive (true);
		//_______SPOILERS________________________________________________________
		//disable all objects
		for (int i = 0; i < Spoilers.Length; i++) {
			Spoilers[i].SetActive (false);
		}
		//enable only selected object
		Spoilers[SpoilerSelected].SetActive (true);
		//_______WHEELS________________________________________________________
		//____FL___________
		//disable all objects
		for (int i = 0; i < WheelFL.Length; i++) {
			WheelFL[i].SetActive (false);
		}
		//enable only selected object
		WheelFL[WheelsSelected].SetActive (true);
		//____FR___________
		//disable all objects
		for (int i = 0; i < WheelFR.Length; i++) {
			WheelFR[i].SetActive (false);
		}
		//enable only selected object
		WheelFR[WheelsSelected].SetActive (true);
		//____RL___________
		//disable all objects
		for (int i = 0; i < WheelRL.Length; i++) {
			WheelRL[i].SetActive (false);
		}
		//enable only selected object
		WheelRL[WheelsSelected].SetActive (true);
		//____RR___________
		//disable all objects
		for (int i = 0; i < WheelRR.Length; i++) {
			WheelRR[i].SetActive (false);
		}
		//enable only selected object
		WheelRR[WheelsSelected].SetActive (true);
	}
}
