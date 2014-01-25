using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float cameraSpeed;

	void Start() {
		rigidbody2D.velocity = new Vector2 (cameraSpeed, 0);


	}

}
