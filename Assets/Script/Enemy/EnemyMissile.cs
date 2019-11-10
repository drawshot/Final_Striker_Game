using UnityEngine;
using System.Collections;

public class EnemyMissile : MonoBehaviour {

	int speed = 15;
	void Update () {
		float amtMove = speed * Time.smoothDeltaTime;
		transform.Translate(Vector3.back * amtMove);
		if(transform.position.z < -20) {
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
