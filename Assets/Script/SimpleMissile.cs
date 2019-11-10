using UnityEngine;
using System.Collections;

public class SimpleMissile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(transform.position.x < -25 || transform.position.x > 25) {
			Destroy(gameObject);
		}
		if(transform.position.z < -20 || transform.position.z > 32) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider coll){
		if(coll.transform.tag == "Player"){
			coll.SendMessage("HitEnemyMissile", transform.position, 
			                 SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
	void DestroySelf()
	{
		Destroy(gameObject);
	}
}
