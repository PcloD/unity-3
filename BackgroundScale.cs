using UnityEngine;
using System.Collections;

// Scale an object so that it fits the screen

public class BGScaler : MonoBehaviour {

	void Start () {
		float height = Camera.main.orthographicSize * 2f;
		float width = height * Screen.width / Screen.height;

		transform.localScale = new Vector3 (width, height, 0);
	}
}
