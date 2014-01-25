using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject man;
	public GameObject woman;

	private bool isManActive = true;
	private Matrix4x4 mat;

	// Use this for initialization
	void Start () {
		mat = Camera.main.projectionMatrix;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("SWITCH");
			isManActive = !isManActive;
			man.GetComponent<Character>().activePlayer = isManActive;
			woman.GetComponent<Character>().activePlayer = !isManActive;

			mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
			Camera.main.projectionMatrix = mat;
			//Quaternion rot = Camera.main.transform.rotation;
			//Camera.main.transform.rotation = new Quaternion(rot.w, rot.x, rot.y, isManActive ? 0 : 180);

			Camera.main.transform.Rotate(0,0,180);
		}

	}
}
