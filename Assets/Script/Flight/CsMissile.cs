using UnityEngine;
using System.Collections;

public class CsMissile : MonoBehaviour {



	int speed = 35;


	void Update () {
		float amtMove = speed * Time.smoothDeltaTime;
		transform.Translate(Vector3.forward * amtMove);
		if(transform.position.z>35) {
			Destroy(gameObject);
		}
	}
	// 미사일 충돌 처리
	void OnTriggerEnter(Collider coll){
		if(coll.transform.tag == "Enemy"){
			coll.SendMessage("HitMissile", transform.position, 
			                 SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	//	if(coll.transform.tag == "EnemyRed"){
	//		coll.SendMessage("HitMissile", transform.position, 
	//		                 SendMessageOptions.DontRequireReceiver);
	//		Destroy(gameObject);
	//	}
	//	if (coll.transform.tag == "Boss") {
	//		coll.SendMessage ("HitMissile", transform.position, SendMessageOptions.DontRequireReceiver);
	//		Destroy (gameObject);
	//	}
	}
}
