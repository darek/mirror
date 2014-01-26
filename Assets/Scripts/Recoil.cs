using UnityEngine;
using System.Collections;
	
public class Recoil : MonoBehaviour {

	public float recoilForceY = 200f;
	public float recoilForceX = -150f;

	private GameController gameController;
	private bool eventHandled = false;
	private float exitTime = 0;
	
	void Start(){
		gameController = GameObject.Find ("GUI_Dot").GetComponent<GameController>();
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("recoil");
		float currentTime = Time.time * 1000;
		if(!eventHandled && currentTime - exitTime > 100f){
			if (collider.gameObject.tag == "Player") {
				collider.gameObject.rigidbody2D.velocity = new Vector2 (0f, 0f);
				collider.gameObject.rigidbody2D.AddForce ((new Vector2 (recoilForceX, recoilForceY)));
				collider.gameObject.GetComponent<Animator> ().SetBool ("Recoil", true);

				if(collider.gameObject.GetComponent<Character>().activePlayer){
					decreaseHeart();
					eventHandled = true;
				}

			}
		}
	}

	void OnTriggerExit2D (Collider2D other){
		eventHandled = false;
		exitTime = Time.time * 1000;
	}

	private void decreaseHeart(){
		gameController.decreaseHeart();
	}
}
