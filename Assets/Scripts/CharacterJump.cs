using UnityEngine;
using System.Collections;

public class CharacterJump : MonoBehaviour {

	public bool canDoubleJump = false; // postac potrafi wykonac double jump
	public float jumpForce = 7f;

	private bool jumping = false; // postac akurat skacze
	private bool secondJump = false;
	private bool grounded = true; // postac akurat jest na ziemi
	private Transform groundChecker; // obiekt na ktorym sprawdzamy pozycje postaci wzgledem podloza
	private Animator animator;

	public GameObject mirror;


	// Use this for initialization
	void Awake () {
		groundChecker = transform.Find("groundChecker");
		animator = GetComponent<Animator>();
	}

	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundChecker.position, 1 << LayerMask.NameToLayer("Ground"));

		if(Input.GetButton("Jump") && (grounded || canDoubleJump)){
			jumping = true;
		}

	}

	void FixedUpdate(){
		if(jumping){
			animator.SetTrigger("Jump");
			Debug.Log ("SKACZE!!");
			rigidbody2D.AddForce(new Vector2(0f,-jumpForce));
			//if(!canDoubleJump || secondJump){
			//	jumping = false;
			//}

		}
		jumping = false;

	}
}
