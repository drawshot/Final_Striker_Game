using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	void OnTriggerEnter(Collider coll){

		if(coll.transform.tag == "Enemy"){
			coll.SendMessage("HitBomb", transform.position, 
			                 SendMessageOptions.DontRequireReceiver);
		}
		if (coll.transform.tag == "EnemyMissile") {
			Manager.manager.Score += 100;
			coll.SendMessage ("DestroySelf", transform.position, SendMessageOptions.DontRequireReceiver);
		}
//		if (coll.transform.tag == "Boss") {
//			Manager.manager.Score += 2000;
//			coll.SendMessage ("HitBomb", transform.position, SendMessageOptions.DontRequireReceiver);
//		}
//		if (coll.transform.tag == "EnemyRed") {
//			Manager.manager.Score += 300;
//			coll.SendMessage ("HitBomb", transform.position, SendMessageOptions.DontRequireReceiver);
//		}
	}
}