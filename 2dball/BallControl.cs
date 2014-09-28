using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour
{
	public float rotationSpeed = 100;
	public float jumpHeight = 8;
	public AudioClip Hit01;
	public AudioClip Hit02;
	public AudioClip Hit03;
	
	private bool isFalling = false;
	private bool playOnce = true;

	void Update () 
	{
		//Handle Ball Rotation
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime;
		rigidbody.AddRelativeTorque (Vector3.back * rotation);	

		if (Input.GetKeyDown(KeyCode.W) && isFalling == false)
		{	
			Vector3 vel = rigidbody.velocity;
			vel.y = jumpHeight;
			rigidbody.velocity = vel;
			PlayOnceTrue ();
		}
		isFalling = true;
	}

	void OnCollisionStay ()
	{
		if (playOnce == true) 
		{
			float theHit = Random.Range(0,4);
			if(theHit == 0)
			{
				audio.clip = Hit01;
			}
			else if(theHit == 1)
			{
				audio.clip = Hit02;
			}
			else
			{
				audio.clip = Hit03;
			}

			audio.Play();
			playOnce = false;		
		}
		isFalling = false;
	}

	IEnumerator PlayOnceTrue()
	{
		yield return new WaitForSeconds (0.2f);
		playOnce = true;
	}

}
