using UnityEngine;
using System.Collections;

public class Crowd : MonoBehaviour {

	public AudioClip goalScored;
	public AudioClip goalSaved;

	private AudioSource _actionAudioSource;

	void Start ()
	{
		_actionAudioSource = GetComponents<AudioSource>()[0];
    }

	public void GoalScored()
	{
		Play(goalScored);
    }

	public void GoalSaved()
	{
		Play(goalSaved);
	}

	private void Play(AudioClip clip)
	{
		_actionAudioSource.Stop();
		_actionAudioSource.clip = clip;
		_actionAudioSource.Play();
	}
}
