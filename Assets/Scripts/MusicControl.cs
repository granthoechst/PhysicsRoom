using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour {

	public AudioMixerSnapshot glass;
	public AudioMixerSnapshot rubber;
	public AudioMixerSnapshot sticky;
	public AudioClip[] stings;
	public AudioSource stingSource;
	public float bpm = 75;

	private float m_TransitionIn;
	private float m_QuarterNote;

	// Use this for initialization
	void Start ()
	{
		m_QuarterNote = 60 / bpm;
		m_TransitionIn = m_QuarterNote / 2;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Glass"))
		{
			glass.TransitionTo (m_TransitionIn);
			PlaySting ();
		}
		else if (other.CompareTag ("Rubber"))
		{
			rubber.TransitionTo (m_TransitionIn);
			PlaySting ();
		}
		else if (other.CompareTag ("Sticky"))
		{
			sticky.TransitionTo (m_TransitionIn);
			PlaySting ();
		}


	}

	void PlaySting()
	{
		int randClip = Random.Range (0, stings.Length);
		stingSource.clip = stings [randClip];
		stingSource.Play();
	}
}
