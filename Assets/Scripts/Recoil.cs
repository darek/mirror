using UnityEngine;
using System.Collections;
	
public class Recoil : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log("Recoil");
		collider.gameObject.rigidbody2D.velocity = new Vector2(0f,0f);
		collider.gameObject.rigidbody2D.AddForce((new Vector2(-5000f,300f)));
	}
}
