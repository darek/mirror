using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	[HideInInspector]
	public bool activeCharacter = false;


	public float maxSpeed = 5f;

	public bool canDoubleJump = false;
	public bool canCrawl = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		float hForce = Input.GetAxis("Horizontal");

		Debug.Log(hForce);

			rigidbody2D.velocity = new Vector2( hForce * maxSpeed, rigidbody2D.velocity.y);



	}
	



}
