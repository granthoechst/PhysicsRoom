using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour {

	public AudioClip[] stickSounds;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Projectile" && collision.gameObject.GetComponent<Rigidbody>())
		{
			collision.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			PlayStick (collision.gameObject);
		}
	}

	void PlayStick(GameObject s)
	{
		AudioSource stickSource = s.AddComponent<AudioSource> ();
		stickSource.spatialBlend = 1;
		stickSource.pitch = 1;
		stickSource.volume = 1;
		int randClip = Random.Range (0, stickSounds.Length);
		stickSource.clip = stickSounds [randClip];
		stickSource.Play();
	}
}
