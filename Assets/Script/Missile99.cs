using UnityEngine;
using System.Collections;

public class Missile99 : MonoBehaviour {

	public float speed;
	public GameObject target;
	public Vector3 Vec;

	void Start () {
		speed = 15;
		Vec = (target.transform.position - transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += Vec * Time.deltaTime * speed;
		transform.forward = Vec;
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
}
