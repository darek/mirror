using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	[HideInInspector]
	public bool activeCharacter = false;
	
	public float maxSpeed = 5f;

	public bool activePlayer = false;
	public GameObject mirror;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!activePlayer){
			transform.position = new Vector2(mirror.transform.position.x, -mirror.transform.position.y);
		}

	}

	void FixedUpdate(){
		float hForce = Input.GetAxis("Horizontal");
		if (activePlayer) {
			//rigidbody2D.velocity = new Vector2 (hForce * maxSpeed, rigidbody2D.velocity.y);
			rigidbody2D.velocity = new Vector2 (1.2f,rigidbody2D.velocity.y);
		} 
	}

}
