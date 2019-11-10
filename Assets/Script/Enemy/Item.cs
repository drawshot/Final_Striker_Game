using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	int speed = 3;
	public AudioClip SndItem;


	void Update () {
		float amtMove = speed * Time.smoothDeltaTime;
		transform.Translate(Vector3.down * amtMove);
		if(transform.position.z < -20) {
			Destroy(gameObject);
		}
	}
	void DestroySelf(){
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint(SndItem, transform.position);
	}
}
