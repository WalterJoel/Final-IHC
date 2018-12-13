using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhaust : MonoBehaviour {

	public ParticleSystem[] Exhausts;
	private AudioSource source;

	void Start(){
		source = gameObject.GetComponent<AudioSource> ();
	}

	public void EmitFlame(){
		foreach (ParticleSystem system in Exhausts) {
			system.Play ();
		}

		if (source)
			source.Play ();
	}
}
