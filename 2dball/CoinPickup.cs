using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour 
{
	public Transform coinEffect;
	public Counter c_counter;
	
	void OnTriggerEnter (Collider info) 
	{
		if (info.tag == "Player") 
		{
			Transform effect;
			effect = Instantiate(coinEffect, transform.position, transform.rotation) as Transform;
			Destroy(effect.gameObject, 3);﻿
			Destroy(gameObject);

			c_counter.count += 1;
			c_counter.SetCountText();
		}
	}

}
