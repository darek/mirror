using UnityEngine;
using System.Collections;

public class MonsterEating : MonoBehaviour {
	
	public Animator animator;

	public AudioClip monsterSound;
	
	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.GetComponent<Character>().Die();
			animator.SetTrigger ("Eat");
			AudioSource.PlayClipAtPoint(monsterSound, transform.position);
		}
	}
}
