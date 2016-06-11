using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class characterInputControl : MonoBehaviour {

	public int jumpForce;                                         
	public Transform grounded;                                                             // Character's children object indicating where to check for ground
	public LayerMask whatIsGround;                                                         // Layer for what is Mask
	public Transform colider;                                                              // Children object indicating top of the collider
	public float slideTime;
	public float coliderVariation;                                                         // float indicating how the colider will change in size

	private Animator anim;
	private Rigidbody2D rigidbody;
	private bool isGrounded;
	private bool isSliding;
	private float time;

	void Start () {
		isGrounded = true;
		isSliding = false;
		anim 	  = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (Input.GetButtonDown ("Jump") && isGrounded) {                                     // Jumping
			rigidbody.AddForce (new Vector2(0f, jumpForce));
			if (isSliding) {
				colider.position = new Vector3 (colider.position.x, 
				                                colider.position.y + coliderVariation, 
				                                colider.position.z);
				isSliding = false;
			}
		}

		if (!isGrounded && rigidbody.velocity.y < 0)                                          // Tells if the characters is falling from a jump, used to change Animations
			anim.SetBool ("isFalling", true);
		else
			anim.SetBool ("isFalling", false);

		if (Input.GetButtonDown ("Slide") && isGrounded && !isSliding) {                      // Sliding
			colider.position = new Vector3 (colider.position.x, 
			                                colider.position.y - coliderVariation, 
			                                colider.position.z);
			isSliding = true;
			time = 0;
		}

		isGrounded = Physics2D.OverlapCircle (grounded.position, 0.2f, whatIsGround);         // getting if is grounded
		
		if (isSliding) {                                                                      // Time control on Sliding
			time += Time.deltaTime;
			if (time >= slideTime) {
				colider.position = new Vector3 (colider.position.x, 
				                                colider.position.y + coliderVariation, 
				                                colider.position.z);
				isSliding = false;
			}
		}

		anim.SetBool ("isJumping", !isGrounded);                                              // set jumping animation if is jumping
		anim.SetBool ("isSliding", isSliding);                                                // set sliding animation if is sliding
	}
}
