using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float cameraSpeed = 5.5f;

	void FixedUpdate(){
		//print("Camera moving at " + camera.velocity.magnitude + " m/s");
		rigidbody2D.velocity = new Vector2 (cameraSpeed,0);
		//rigidbody2D.velocity = new Vector2 (cameraSpeed, 0);

	}

}
