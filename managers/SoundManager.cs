using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public static SoundManager instance = null;

	public AudioSource efxSource; 				// sound effects source
	public AudioSource musicSource;				// music source

	// Play a clip
	public void PlaySingle(AudioClip clip)
	{
		efxSource.clip = clip;
		efxSource.Play ();
	}

	public static SoundManager getInstance()
	{
		return instance;
	}

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
      
      // this is optional
      //DontDestroyOnLoad(this);
	}

}

/*
  Sound Manager that is a Singleton (you can see it the design patterns section in this repository
  To play a sound on the scene, create a public AudioClip on the object that will trigger the sound play and when it is
  the time to do it, call SoundManager.getInstance().PlaySingle(audioclip);
*/
