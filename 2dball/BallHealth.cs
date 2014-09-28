using UnityEngine;
using System.Collections;

public class BallHealth : MonoBehaviour 
{
	public float maxFallDistance = -10;
	public AudioClip GameOverSound;

	private bool isRestarting = false;	

	void Update () 
	{
		if (transform.position.y <= maxFallDistance) 
		{
			if(isRestarting == false)
			{
				StartCoroutine	(RestartLevel());
			}
		}
	}

	IEnumerator RestartLevel()
	{
		isRestarting = true;
		audio.clip = GameOverSound;
		audio.Play ();
		yield return new WaitForSeconds (audio.clip.length);
		Application.LoadLevel("Level01");
	}
}
