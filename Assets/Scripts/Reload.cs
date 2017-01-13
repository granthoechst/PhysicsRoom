using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("r") || Input.GetKeyDown ("joystick button 19"))
		{
			Application.LoadLevel ("The Room");
		}
	}
}
