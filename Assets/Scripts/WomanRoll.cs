using UnityEngine;
using System.Collections;

public class WomanRoll : MonoBehaviour {

	private Animator anim;					// Reference to the player's animator component.
	private BoxCollider2D boxCollider;
	private bool isRolling = false;

	private bool active = false;

	void Awake()
	{
		anim = GetComponent<Animator>();
		boxCollider = GetComponent<BoxCollider2D>();
		active = GetComponent<Character> ().activePlayer;
	}	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Roll")) {
			Debug.Log ("DOWN");
			isRolling = true;
		}
	}

	void FixedUpdate(){
		float hForce = Input.GetAxis("Horizontal");
		anim.SetFloat("Speed",  Mathf.Abs(hForce));

		Debug.Log ("active: " + active);
		if (active && isRolling) {
			anim.SetTrigger ("Roll");
			//boxCollider.size = new Vector2(boxCollider.size.x, boxCollider.size.y-10);
		}
		isRolling = false;
	}
}
