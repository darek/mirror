using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject man;
	public GameObject woman;

	public GameObject startPoint;
	public GameObject endPoint;

	private bool isManActive = true;
	private Matrix4x4 mat;

	private float startPointX;
	private float wholeDistance;
	private float cameraWidth;

	public AudioClip changeWorlds;

	// Use this for initialization
	void Start () {
		mat = Camera.main.projectionMatrix;

		// inicjalizujemy pola potrzebne do obliczenia poziomu HUD-pointa
		startPointX = startPoint.transform.position.x;
		float endPointX = endPoint.transform.position.x;
		wholeDistance = Mathf.Abs (endPointX - startPointX);

		//http://answers.unity3d.com/questions/230190/how-to-get-the-width-and-height-of-a-orthographic.html#answer-230205
		Camera cam = Camera.main;
		float height = 2f * cam.orthographicSize;
		cameraWidth = height * cam.aspect;
		Debug.Log ("whole: " + wholeDistance);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("SWITCH");
			AudioSource.PlayClipAtPoint(changeWorlds, transform.position);

			isManActive = !isManActive;
			man.GetComponent<Character>().activePlayer = isManActive;
			woman.GetComponent<Character>().activePlayer = !isManActive;

			mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
			Camera.main.projectionMatrix = mat;
			//Quaternion rot = Camera.main.transform.rotation;
			//Camera.main.transform.rotation = new Quaternion(rot.w, rot.x, rot.y, isManActive ? 0 : 180);

			Camera.main.transform.Rotate(0,0,180);
		}

		refreshHUDBar ();
	}

	private void refreshHUDBar(){
		Camera camera = Camera.main;
		float distanceDone = Mathf.Abs(camera.transform.position.x - startPointX);
		float distancePercent = distanceDone / wholeDistance;

		float regardsToCameraCenter = (distancePercent * cameraWidth) - (cameraWidth/2);
		float newX = camera.transform.position.x + regardsToCameraCenter;
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	}
}
