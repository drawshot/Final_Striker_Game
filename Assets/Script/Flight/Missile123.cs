using UnityEngine;
using System.Collections;

public class Missile123 : MonoBehaviour {

	
	public float   RotationSpeed ;
	public float  MoveSpeed;
	private Quaternion m_QuterA;
	private Quaternion m_QuterS;
	
	private Vector3  ViewVector;
	
	
	
	void Start(){
		Destroy (gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {

		var obj = GameObject.FindGameObjectWithTag("Enemy");
		ViewVector = obj.gameObject.transform.position - transform.position;
		
		m_QuterA = Quaternion.LookRotation (ViewVector, new Vector3 (0, 1, 0));
		
		
		m_QuterS = Quaternion.Slerp (transform.rotation, m_QuterA, RotationSpeed * Time.deltaTime);
		transform.rotation = m_QuterS;
		
		
		transform.Translate (new Vector3 (0, 0, 1) * MoveSpeed * Time.deltaTime);

		
	}
		void OnTriggerEnter(Collider coll){
		if(coll.transform.tag == "Enemy"){
			coll.SendMessage("HitMissile", transform.position, 
			                 SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
		if(coll.transform.tag == "EnemyRed"){
			coll.SendMessage("HitMissile", transform.position, 
			                 SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
		if (coll.transform.tag == "Boss") {
			coll.SendMessage ("HitMissile", transform.position, SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		}
	}
}
	