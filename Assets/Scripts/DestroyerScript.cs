using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyerScript: MonoBehaviour {
	
	public Dictionary<string, GameObject> creators = new Dictionary<string, GameObject>();
	
	public GameObject grassCreator;
	public GameObject cloudCreator;
	
	void Start(){
		creators.Add("grass", grassCreator);
		creators.Add("cloud", cloudCreator);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (creators.ContainsKey (other.tag)) {
			Vector3 position = other.gameObject.transform.position;

			GameObject creator = creators [other.tag];
			creator.GetComponent<CreatorScript> ().create (position);

			BackgroundElementScript script = other.gameObject.GetComponent<BackgroundElementScript> ();

			if (script.canBeDeleted) {
					Destroy (script.mirrored);
					Destroy (other.gameObject);
			}
		} else if (other.tag == "backgroundElement") {
			BackgroundElementScript script = other.gameObject.GetComponent<BackgroundElementScript> ();

			if(script.canBeDeleted) {
				Destroy (script.mirrored);
				Destroy (other.gameObject);
			}
		}
	}
	
	
}