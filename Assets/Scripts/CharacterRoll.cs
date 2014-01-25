using UnityEngine;
using System.Collections;

public class CharacterRoll : MonoBehaviour {

	private Animator anim;					// Reference to the player's animator component.
	private BoxCollider2D boxCollider;
	private bool isRolling = false;

	void Awake()
	{
		anim = GetComponent<Animator>();
		boxCollider = GetComponent<BoxCollider2D>();
	}	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			isRolling = true;
		}
	}

	void FixedUpdate(){
		float hForce = Input.GetAxis("Horizontal");
		Debug.Log (hForce);
		anim.SetFloat("Speed",  Mathf.Abs(hForce));

		if (isRolling && Mathf.Abs(hForce) > 0) {
			anim.SetTrigger ("Roll");
			//boxCollider.size = new Vector2(boxCollider.size.x, boxCollider.size.y-10);
		}
		isRolling = false;
	}
}
