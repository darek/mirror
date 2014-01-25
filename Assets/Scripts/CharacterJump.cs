using UnityEngine;
using System.Collections;

/**
 * Klasa odpowiedzialna za skakanie
 * PAMIETAJ ABY:
 * 1. Postac miala w sobie obiekt o nazwie 'groundChecker'
 * 2. Ziemia po ktorej postac chodzi byla w warstwie 'Ground'
 */
public class CharacterJump : MonoBehaviour {

	public bool canSecondJump = false; // postac potrafi wykonac double jump
	public float jumpForce = 20f;
	public bool isMirrored = false;

	private bool jumping = false; // postac akurat skacze
	private bool secondJump = false;
	private bool grounded = true; // postac akurat jest na ziemi
	private Transform groundChecker; // obiekt na ktorym sprawdzamy pozycje postaci wzgledem podloza
	private Animator animator;
	
	void Awake() {
		groundChecker = transform.Find("groundChecker");
		animator = GetComponent<Animator>();
	}

	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundChecker.position, 1 << LayerMask.NameToLayer("Ground"));
		animator.SetBool("Grounded",grounded);

		if(Input.GetButtonDown("Jump")){
			jumping = true;
		}

		// jesli jest na ziemi to zerujemy podwojny skok
		if(grounded){
			secondJump = false;
		}
	}

	void FixedUpdate(){
		// sprawdzamy czy gracz jest aktualnie na ziemi


		if((grounded || (!secondJump && canSecondJump)) && jumping){
			if(!grounded){
				secondJump = true;
			}
			animator.SetBool("Grounded",false);
			animator.SetTrigger("Jump");
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,0f); // zerujemy predkosc wysokosci
			rigidbody2D.AddForce(new Vector2(0f,(isMirrored ? -1 : 1 ) * jumpForce));
		}
		jumping = false;

	}
}
