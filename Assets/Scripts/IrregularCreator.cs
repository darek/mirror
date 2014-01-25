using UnityEngine;
using System.Collections;

public class IrregularCreator : MonoBehaviour {
	public GameObject[] objects;
	public float spawnMin = 0.5f;
	public float spawnMax = 3f;

	void Start(){
		Spawn();
	}

	void Spawn(){
		GameObject randomObj = objects[Random.Range(0, objects.Length)];
		Vector3 newPosition = new Vector3(transform.position.x, randomObj.transform.position.y, randomObj.transform.position.z);
		GameObject newObject = Instantiate(randomObj, newPosition, Quaternion.identity) as GameObject;
		newObject.GetComponent<BackgroundElementScript> ().canBeDeleted = true;
		CreatorScript.CreateMirrored (newObject);
		Invoke("Spawn", Random.Range(spawnMin, spawnMax));
	}
}