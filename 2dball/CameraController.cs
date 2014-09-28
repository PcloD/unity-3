using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Transform target;
	public float distance = -10.0f;
	
	void Update () 
	{
		Vector3 cameraDistance = new Vector3 (0.0f, 0.0f, distance);
		transform.position = target.position + cameraDistance;
	}
}
