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
	private bool endJumping = false;
	private bool secondJump = false;
	private bool grounded = true; // postac akurat jest na ziemi
	private Transform groundChecker; // obiekt na ktorym sprawdzamy pozycje postaci wzgledem podloza
	private Animator animator;
	private bool active = false;

	public AudioClip jumpSound;

	void Awake() {
		groundChecker = transform.Find("groundChecker");
		animator = GetComponent<Animator>();
	}

	void Update () {
		active = GetComponent<Character> ().activePlayer;
		grounded = Physics2D.Linecast(transform.position, groundChecker.position, 1 << LayerMask.NameToLayer("Ground"));
		animator.SetBool("Grounded",grounded);

		if(Input.GetButtonDown("Jump")){
			jumping = true;
		}
		if(Input.GetButtonUp ("Jump")){
			endJumping = true;
		}
	}

	void FixedUpdate(){
		// sprawdzamy czy gracz jest aktualnie na ziemi

		if(endJumping){
			float velY = rigidbody2D.velocity.y;
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,velY>0?Mathf.Sqrt(rigidbody2D.velocity.y):velY);
			endJumping = false;
		}

		if((grounded || (!secondJump && canSecondJump && active)) && jumping){
			if(!grounded){
				secondJump = true;
				rigidbody2D.AddForce(new Vector2(0f,(isMirrored ? -1 : 1 ) * jumpForce*1.5f));
			}else{
				float x = rigidbody2D.velocity.x>0?rigidbody2D.velocity.x:1;
				rigidbody2D.velocity = new Vector2(x,0f);
				rigidbody2D.AddForce(new Vector2(0f,(isMirrored ? -1 : 1 ) * jumpForce));
			}
			animator.SetBool("Grounded",false);
			animator.SetTrigger("Jump");

			AudioSource.PlayClipAtPoint(jumpSound ,transform.position);
			//rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,0f); // zerujemy predkosc wysokosci

		}
		jumping = false;

		// jesli jest na ziemi to zerujemy podwojny skok
		if(grounded){
			secondJump = false;
			animator.SetBool("Recoil",false);
		}

	}
}
