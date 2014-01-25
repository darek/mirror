using UnityEngine;
using System.Collections;

public class ParalaxeScript: MonoBehaviour {
	public float speedX = -1f;

	void start() {
		rigidbody2D.velocity = new Vector2 (speedX, 0);
	}
}
