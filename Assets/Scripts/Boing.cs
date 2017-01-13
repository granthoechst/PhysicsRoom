using UnityEngine;
using System.Collections;

public class Boing : MonoBehaviour {

	public AudioClip boing;
	// public AudioSource boingSource;

	void OnCollisionEnter(Collision collision)
	{
		AudioSource boingSource;
		if (collision.gameObject.GetComponent<AudioSource> ()) {
			boingSource = collision.gameObject.GetComponent<AudioSource> ();
		}
		else {
			boingSource = collision.gameObject.AddComponent<AudioSource> ();
		}
		boingSource.clip = boing;
		boingSource.spatialBlend = 1;
		boingSource.volume = 1;
		boingSource.pitch = 1 + (collision.relativeVelocity.magnitude / 100);
		boingSource.Play();
	}
}
