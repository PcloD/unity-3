using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour {

	public GUIText countText;
	public GUIText winText;
	public int count = 0;

	void Start () 
	{
		winText.text = "";
		SetCountText ();
	}

	void Update()
	{
		if (count == 6) 
		{
			winText.text = "You Won m8 >:)";
		}
	}

	public void SetCountText()
	{
		countText.text = "Score: " + count.ToString ();
	}

}
