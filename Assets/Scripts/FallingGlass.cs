using UnityEngine;
using System.Collections;

public class FallingGlass : MonoBehaviour {

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Floor") {
			Destroy (gameObject);
		}
	}
}
