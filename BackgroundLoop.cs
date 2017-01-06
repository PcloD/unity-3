/*
  What is it?
  Simple Code that loop an image background in a quad, very useful for infinite runners, flappy bird similar, basically for
  everything that you want to give the impression of movement but don't want to really move the character because it wouldn't
  be the easiest solution.
 
  How it works?
  The code haves a public speed, an offset and a material (remember that this code is in a Quad).
  It just gets the offset of the material texture and add the speed to it on the Update() function.
  
  How to set it up?
  1. Create a quad in your scene (3D Object)
  2. Remove the Mesh Collider
  
  3. In the image that will loop
    3.1. Set Wrap Mode to Repeat
    3.2. Set Filter Mode to Bilinear
    3.3. Texture type can be Default
  
  4. Create a Material
  5. Change the Material Shader to Alpha Blended (Mobile > Particles > Alpha Blended)
  6. Add the image texture
  
  7. Add the Material to the Quad
  8. Add this code to the quad object, it should now loop.
*/

using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	public float speed = 0.1f;
	private Vector2 offset = Vector2.zero;
	private Material mat;

	void Start() {
		mat = GetComponent<Renderer> ().material;
		offset = mat.GetTextureOffset ("_MainTex");
	}

	void Update () {
		offset.x += (speed * Time.deltaTime);
		mat.SetTextureOffset ("_MainTex", offset);
	}
}
