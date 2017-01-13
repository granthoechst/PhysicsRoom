using UnityEngine;
using System.Collections;

public class Break : MonoBehaviour {

	public Transform broken;
	public float breakSpeed, radius, power, upwards;
	public AudioClip[] breakSounds;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.relativeVelocity.magnitude > breakSpeed)
		{
			Destroy (gameObject);
			Transform t = Instantiate (broken, transform.position, transform.rotation) as Transform;
			GameObject newBroken = t.gameObject;
			PlayBreak (newBroken);
			newBroken.transform.localScale = transform.localScale / 50;
			Vector3 explosion = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosion, radius);

			foreach (Collider hit in colliders)
			{
				if (hit.GetComponent<Rigidbody>())
				{
					hit.GetComponent<Rigidbody>().AddExplosionForce (power*collision.relativeVelocity.magnitude, explosion, radius, upwards);
				}
			}
		}
	}

	void PlayBreak(GameObject b)
	{
		AudioSource breakSource = b.AddComponent<AudioSource> ();
		breakSource.spatialBlend = 1;
		breakSource.pitch = 1;
		breakSource.volume = (float) 0.4;
		int randClip = Random.Range (0, breakSounds.Length);
		breakSource.clip = breakSounds [randClip];
		breakSource.Play();
	}
}
