using UnityEngine;
using System.Collections;
	
public class Recoil : MonoBehaviour {

	public float recoilForceY = 200f;
	public float recoilForceX = -150f;


	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.rigidbody2D.velocity = Vector2.zero;
			collider.gameObject.rigidbody2D.AddForce ((new Vector2 (recoilForceX, recoilForceY)));
			collider.gameObject.GetComponent<Animator> ().SetBool ("Recoil", true);
		}
	}
}
