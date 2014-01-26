using UnityEngine;
using System.Collections;

public class GameWon : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter2D () {
		Debug.Log("asdasd");
		Application.LoadLevel (1);
	}
}
