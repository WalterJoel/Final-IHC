using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscToMenu : MonoBehaviour {

	public GameObject PauseMenu;
	public GameObject CarUI;
	public string GarageScene;
	private bool IsPause=false;
	public bool SlowTime = true;
	public float SlowTimeAmount = 0.3f;
	public bool SlowPitch = true;
	private bool IsPitched = false;
	private AudioSource[] Sources;

	void Start(){
		//do at the start the pause void
		//call void to make pause
		MakePause ();
	}

	// Update is called once per frame
	void Update () {
		//make pause the game or not
		if (Input.GetKeyDown (KeyCode.Escape)) {
			IsPause = !IsPause;
			//if change pitch change it
			if(SlowPitch) IsPitched = !IsPitched;
			//call void to make pause
			MakePause ();
		}

		//check if script should decrease pitch of all audiosource
		if(IsPitched){
			Sources = FindObjectsOfType<AudioSource> ();
			foreach(AudioSource source in Sources){
				source.pitch = source.pitch * SlowTimeAmount;
			}
		}
	}

	//apply pause
	void MakePause(){
		//if pause open menu else close it
		if(IsPause){
			//open menu
			PauseMenu.SetActive (true);
			CarUI.SetActive (false);

			//slow time
			if(SlowTime) Time.timeScale = SlowTimeAmount;
		}
		if (!IsPause) {
			//close menu
			PauseMenu.SetActive (false);
			CarUI.SetActive (true);

			//restore time
			if(SlowTime) Time.timeScale = 1f;
		}
	}

	//return to menu
	public void GoToGarage(){
		//restore time
		if(SlowTime) Time.timeScale = 1f;
		//load menu
		Application.LoadLevel (GarageScene);
	}
}
