using UnityEngine;
using System.Collections;

public class CharackterJump : MonoBehaviour {

	public bool canDoubleJump = false; // postac potrafi wykonac double jump
	public float jumpForce = 7f;

	private bool jumping = false; // postac akurat skacze
	private bool secondJump = false;
	private bool grounded = true; // postac akurat jest na ziemi
	private Transform groundChecker; // obiekt na ktorym sprawdzamy pozycje postaci wzgledem podloza
	private Animator animator;

	// Use this for initialization
	void Awake () {
		groundChecker = transform.Find("groundChecker");
		animator = GetComponent<Animator>();
	}

	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundChecker.position, 1 << LayerMask.NameToLayer("Ground"));

		if(grounded && Input.GetButton("Jump") || canDoubleJump){
			jumping = true;
		}

	}

	void FixedUpdate(){
		if(jumping){
			animator.SetTrigger("Jump");
			rigidbody2D.AddForce(new Vector2(0f,jumpForce));
			if(!canDoubleJump || secondJump){
				jumping = false;
			}
		}
	}
}
