using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float cameraSpeed;

	void Update(){
		print("Camera moving at " + camera.velocity.magnitude + " m/s");
		rigidbody2D.velocity = new Vector2 (5.5f,rigidbody2D.velocity.y);
		//rigidbody2D.velocity = new Vector2 (cameraSpeed, 0);

	}

}
