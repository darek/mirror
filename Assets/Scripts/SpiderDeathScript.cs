using UnityEngine;
using System.Collections;

public class SpiderDeathScript : MonoBehaviour {
	// Update is called once per frame
	void OnTriggerEnter2D () {
		Application.LoadLevel (1);
	}
}
