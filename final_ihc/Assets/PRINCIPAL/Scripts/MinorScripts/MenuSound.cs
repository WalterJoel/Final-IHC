using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour {

	public AudioClip[] Sounds;
	public AudioSource Source;

	public void MakeSound(int i){
		if (!Source.isPlaying) {
			Source.clip = Sounds [i];
			Source.Play ();
		}
	}
}
