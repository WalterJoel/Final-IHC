using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSound : MonoBehaviour {

	public AudioSource source;
	public AudioClip[] clips;
	public bool UseParticles = true;
	public Object Smoke;
	public Object Sparks;
	private Rigidbody rigid;
	public AudioSource ScrapeSource;
	[Tooltip("Make a spark for each contact point!")]
	public bool UseExpensiveEffect = true;

	void Start(){
		if (!source)
			source = gameObject.GetComponent<AudioSource> ();

		if(!rigid) rigid = gameObject.GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void OnCollisionEnter (Collision coll){
		if (coll.relativeVelocity.magnitude > 1) {
			//make sound
			if (source) {
				source.clip = clips [Random.Range (0, clips.Length)];
				source.Play ();
			}
			//make particles if true
			if(UseParticles && Smoke){
				ContactPoint contact = coll.contacts[0];
				Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
				Vector3 pos = contact.point;
				Instantiate(Smoke, pos, rot);
			}
		}
	}
	void OnCollisionStay (Collision coll){
		if (coll.relativeVelocity.magnitude > 1) {
			//make particles if true
			if(UseParticles){
				//make sound
				if (ScrapeSource && !ScrapeSource.isPlaying) {
					ScrapeSource.loop = false;
					ScrapeSource.Play ();
				}
				//make particles if true
				if (Sparks && !UseExpensiveEffect) {
					ContactPoint contact = coll.contacts [0];
					Quaternion rot = Quaternion.FromToRotation (Vector3.back,rigid.velocity);
					Vector3 pos = contact.point;
					Instantiate (Sparks, pos, rot);
				}
				else if (Sparks && UseExpensiveEffect){
					ContactPoint[] contact = coll.contacts;

					foreach (ContactPoint Icontact in contact) {
						Quaternion rot = Quaternion.FromToRotation (Vector3.back, rigid.velocity);
						Vector3 pos = Icontact.point;
						Instantiate (Sparks, pos, rot);
					}
				}
			}
		}
	}
	void OnCollisionExit (Collision coll){
		//stop scrape sound
				if (ScrapeSource) {
					ScrapeSource.loop = false;
					ScrapeSource.Stop ();
				}
	}
}
