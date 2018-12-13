using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceSelect : MonoBehaviour {

	public string SceneToLoad;

	public void LoadScene(){
		Application.LoadLevel (SceneToLoad);
	}
}
