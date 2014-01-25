using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	[HideInInspector]
	public bool activeCharacter = false;
	
	public float maxSpeed = 5.5f;

	public bool activePlayer = false;
	public GameObject mirror;
	public Animator animator;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!activePlayer){
			transform.position = new Vector2(mirror.transform.position.x, -mirror.transform.position.y);
		}

	}

	void FixedUpdate(){
		float hForce = Input.GetAxis("Horizontal");
		if (activePlayer && rigidbody2D.velocity.x>=0) {
			//rigidbody2D.velocity = new Vector2 (hForce * maxSpeed, rigidbody2D.velocity.y);
			rigidbody2D.velocity = new Vector2 (maxSpeed,rigidbody2D.velocity.y);
		} 
	}

}
