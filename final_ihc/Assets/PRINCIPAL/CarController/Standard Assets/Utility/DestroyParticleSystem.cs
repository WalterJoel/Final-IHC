using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour {

	private IEnumerator Start(){
		ParticleSystem ParticleSystem = gameObject.GetComponent<ParticleSystem> ();
		yield return new WaitForSeconds (ParticleSystem.startLifetime + ParticleSystem.duration);
		Destroy (gameObject);
	}
}
