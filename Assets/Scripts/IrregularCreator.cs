using UnityEngine;
using System.Collections;

public class IrregularCreator : MonoBehaviour {
	public GameObject[] objects;
	public float spawnMin = 1f;
	public float spawnMax = 2f;

	void Start(){
		Spawn();
	}

	void Spawn(){
		GameObject randomObj = objects[Random.Range(0, objects.Length)];
		Vector3 newPosition = new Vector3(transform.position.x, randomObj.transform.position.y, randomObj.transform.position.z);
		Instantiate(randomObj, newPosition, Quaternion.identity);
		Invoke("Spawn", Random.Range(spawnMin, spawnMax));
	}
}