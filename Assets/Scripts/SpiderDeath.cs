using UnityEngine;
using System.Collections;

public class SpiderDeath : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter2D () {
		Application.LoadLevel (1);
	}
}
