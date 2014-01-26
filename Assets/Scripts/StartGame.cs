using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public AudioClip audio;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			AudioSource.PlayClipAtPoint(audio, transform.position);
			Application.LoadLevel(2);
		}
	}
}
