using UnityEngine;
using System.Collections;

public class GameWon : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.tag=="Player"){
			Application.LoadLevel (3);
		}
	}
}
