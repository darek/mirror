using UnityEngine;
using System;

public class CreatorScript : MonoBehaviour {
	public GameObject theLastOne;

	public GameObject [] patternObjects = new GameObject[] {};

	// liczba ile razy trzeba powtorzyc obiekt, zeby zajal cala przestrzen, domyslnie 16
	public int objectNTimesRepeated = 16;

	void Start(){
		GameObject current = theLastOne;

		CreateMirrored (current);

		for(int i=0; i<objectNTimesRepeated; ++i){
			current = CreateNextHorizontal(current);
			CreatorScript.CreateMirrored(current);
		}

		theLastOne = current;
	}

	private GameObject CreateNextHorizontal(GameObject previous){
		Vector3 newlyCreatedPosition = new Vector3 (previous.transform.position.x + previous.renderer.bounds.size.x, previous.transform.position.y, previous.transform.position.z);
		GameObject newlyCreated = cloneGameObject(chooseRandomPatternObject(), newlyCreatedPosition);
		return newlyCreated;
	}

	public static GameObject CreateMirrored(GameObject toMirror){
		BackgroundElementScript backgroundElement = toMirror.GetComponent<BackgroundElementScript> ();

		GameObject patternObject = null;
		if (backgroundElement.mirrored)
				patternObject = backgroundElement.mirrored;
			else
				patternObject = toMirror;

		Vector3 mirrroredPosition = new Vector3(toMirror.transform.position.x, -toMirror.transform.position.y, toMirror.transform.position.z);
		GameObject mirrored = cloneGameObject(patternObject, mirrroredPosition);
		mirrored.transform.localScale = new Vector3(mirrored.transform.localScale.x, -1f, mirrored.transform.localScale.z);
		toMirror.GetComponent<BackgroundElementScript> ().mirrored = mirrored;
		return mirrored;
	}

	private GameObject chooseRandomPatternObject(){
		System.Random random = new System.Random();
		int index = random.Next(0, patternObjects.Length);

		return patternObjects[index];
	}

	public void create(Vector3 destroyedObjectPosition){
		if(theLastOne){
			GameObject newObjectPattern = chooseRandomPatternObject();
			float paddingX = (theLastOne.renderer.bounds.size.x + newObjectPattern.renderer.bounds.size.x)/2f;
			Vector3 newlyCreatedPosition = new Vector3(theLastOne.transform.position.x + paddingX, destroyedObjectPosition.y, destroyedObjectPosition.z);

			GameObject newlyCreated = cloneGameObject(newObjectPattern, newlyCreatedPosition);

			CreatorScript.CreateMirrored(newlyCreated);

			theLastOne = newlyCreated;
		}
	}

	private static GameObject cloneGameObject(GameObject gameObject, Vector3 position){
		GameObject newlyCreated = Instantiate(gameObject, position, Quaternion.identity) as GameObject;
		newlyCreated.GetComponent<BackgroundElementScript>().canBeDeleted = true;
		return newlyCreated;
	}
}