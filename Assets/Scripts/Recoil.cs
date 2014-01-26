using UnityEngine;
using System.Collections;
	
public class Recoil : MonoBehaviour {

	public float recoilForceY = 200f;
	public float recoilForceX = -150f;
	public AudioClip ouchSound;

	private GameController gameController;
	private bool eventHandled = false;
	private float exitTime = 0;
	
	void Start(){
		gameController = GameObject.Find ("GUI_Dot").GetComponent<GameController>();
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("recoil");
		//if (!eventHandled) {
			
			if (collider.gameObject.tag == "Player") {
				//collider.gameObject.rigidbody2D.velocity = Vector2.zero;
				collider.gameObject.rigidbody2D.velocity = new Vector2(collider.gameObject.rigidbody2D.velocity.x,0f);
				collider.gameObject.rigidbody2D.AddForce ((new Vector2 (collider.gameObject.rigidbody2D.velocity.x, recoilForceY)));
				collider.gameObject.GetComponent<Animator> ().SetBool ("Recoil", true);
				if (collider.gameObject.GetComponent<Character> ().activePlayer) {
					AudioSource.PlayClipAtPoint (ouchSound, transform.position);

					float currentTime = Time.time * 1000;
					if(!eventHandled && (currentTime - exitTime > 100f)){
						eventHandled = true;
						decreaseHeart ();
					}
				}
			}
		//}
	}

	void OnTriggerExit2D (Collider2D other){
		eventHandled = false;
		exitTime = Time.time * 1000;
	}

	private void decreaseHeart(){
		gameController.decreaseHeart();
	}
}
