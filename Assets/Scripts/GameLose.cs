using UnityEngine;
using System.Collections;

public class GameLose : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D collider) {
		if(collider.gameObject.tag=="Player"){
			lose();
		}
	}

	public void lose(){
		Application.LoadLevel (1);
	}
}
