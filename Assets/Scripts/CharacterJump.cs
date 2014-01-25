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
		if(Input.GetButtonDown("Jump")){
			jumping = true;
		}
	}

	void FixedUpdate(){
		// sprawdzamy czy gracz jest aktualnie na ziemi
		grounded = Physics2D.Linecast(transform.position, groundChecker.position, 1 << LayerMask.NameToLayer("Ground"));
		animator.SetBool("Grounded",grounded);

		if((grounded || (!secondJump && canSecondJump)) && jumping){
			Debug.Log("grounded: "+grounded);
			if(!grounded){
				Debug.Log ("Drugi skok!");
				secondJump = true;
			}
			Debug.Log ("skok!");
			animator.SetTrigger("Jump");
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,0f); // zerujemy predkosc wysokosci
			rigidbody2D.AddForce(new Vector2(0f,jumpForce));
		}
		jumping = false;

		// jesli jest na ziemi to zerujemy podwojny skok
		if(grounded){
			secondJump = false;
		}
		jumping = false;

	}
}
