/*
  Restricts the Instantiation of a class to ONE object
*/

using UnityEngine;
using System.Collections;

public class SingletonClass : MonoBehaviour {

  // static attribute will hold the instance
	public static SingletonClass instance = null;

  // static method to get the instance
	public static SingletonClass getInstance()
	{
		return instance;
	}

  // Setting the instance or destroying the object
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

    // if this is the instance, don't destroy it
		DontDestroyOnLoad(gameObject);
	}
}

/*
  HOW TO USE IT:
  Just add this script to the gameObject that you want to instantiate only once.
  Singleton pattern is useful for objects that must persist in every scene and shouldn't be destroyed
*/
