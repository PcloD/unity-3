using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour 
{
	public Texture2D fadeOutTexture; //texture that will overlay the screen
	public float fadeSpeed = 0.8f;   // fade velocity
	
	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;       // fade Direction
									// -1 -> black to clear
									// 1  -> into black screen

	void OnGUI()
	{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), fadeOutTexture);
	}
	
	public float BeginFade (int direction)
	{
		fadeDir = direction;
		return (fadeSpeed);
	}
	
	// Calls Fading automatically when new level is loaded
	void OnLevelWasLoaded()
	{
		BeginFade (-1);
	}
}

/*
-------------------------------------------------
			HOW TO USE IT
-------------------------------------------------
1) Create a IEnumerator function that calls BeginFade with direction 1 (or -1 if you want) it should return WaitForSeconds(fadeTime), fadeTime is the return value from function BeginFade
Example:
private IEnumerator myFunction()
{
	float fadeTime = myScript.BeginFade(1)
	yield return new WaitForSeconds(fadeTime);
	Application.LoadLevel("YourLevel");
}

2) just call the subroutine anywhere you want
StartCoroutine(myFunction());
*/
