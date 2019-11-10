using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
	
	Transform spPoint1;
	Transform spPoint2;
	Transform spPoint3;
	public Transform missile;
	int power = 800;
	public static Target target;
	public int TargetFire;

	bool canFire = true;
	// Use this for initialization
	void Start () {
		TargetFire = 1;
		target = this;
		spPoint1 = transform.Find ("spPoint1");
		spPoint2 = transform.Find ("spPoint2");
		spPoint3 = transform.Find ("spPoint3");
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(CsFighter.Fighter.transform);
		if (TargetFire == 1) {
			ShootEnemyMissile ();
		}
	}

	void ShootEnemyMissile()
	{
		int ran = Random.Range (1, 4);
		if (ran == 1) {
			if (canFire == true) {
				StartCoroutine ("MakeEnemyMissile1");
			}
		}
		else if (ran == 2) {
			if (canFire == true) {
				StartCoroutine ("MakeEnemyMissile2");
			}
		}
		else if (ran == 3) {
			if (canFire == true) {
				StartCoroutine ("MakeEnemyMissile3");
			}
		}
	}

	IEnumerator MakeEnemyMissile1()
	{
		canFire = false;
		Transform obj = Instantiate(missile, spPoint1.transform.position, spPoint1.transform.rotation) as Transform;
		obj.GetComponent<Rigidbody>().AddForce(spPoint1.transform.forward * power);
		Transform obj1 = Instantiate(missile, spPoint2.transform.position, spPoint2.transform.rotation) as Transform;
		obj1.GetComponent<Rigidbody>().AddForce(spPoint2.transform.forward * power);
		Transform obj2 = Instantiate(missile, spPoint3.transform.position, spPoint3.transform.rotation) as Transform;
		obj2.GetComponent<Rigidbody>().AddForce(spPoint3.transform.forward * power);
		
		yield return new WaitForSeconds(2f);
		
		canFire = true;
		
	}
	IEnumerator MakeEnemyMissile2()
	{
		canFire = false;
		
		Transform obj = Instantiate(missile, spPoint1.transform.position, spPoint1.transform.rotation) as Transform;
		obj.GetComponent<Rigidbody>().AddForce(spPoint1.transform.forward * power);
		Transform obj1 = Instantiate(missile, spPoint2.transform.position, spPoint2.transform.rotation) as Transform;
		obj1.GetComponent<Rigidbody>().AddForce(spPoint2.transform.forward * power);
		Transform obj2 = Instantiate(missile, spPoint3.transform.position, spPoint3.transform.rotation) as Transform;
		obj2.GetComponent<Rigidbody>().AddForce(spPoint3.transform.forward * power);
		//AudioSource.PlayClipAtPoint(sndMissile, transform.position);
		
		yield return new WaitForSeconds(3f);
		
		canFire = true;
		
	}
	IEnumerator MakeEnemyMissile3()
	{
		canFire = false;
		
		Transform obj = Instantiate(missile, spPoint1.transform.position, spPoint1.transform.rotation) as Transform;
		obj.GetComponent<Rigidbody>().AddForce(spPoint1.transform.forward * power);
		Transform obj1 = Instantiate(missile, spPoint2.transform.position, spPoint2.transform.rotation) as Transform;
		obj1.GetComponent<Rigidbody>().AddForce(spPoint2.transform.forward * power);
		Transform obj2 = Instantiate(missile, spPoint3.transform.position, spPoint3.transform.rotation) as Transform;
		obj2.GetComponent<Rigidbody>().AddForce(spPoint3.transform.forward * power);
		//AudioSource.PlayClipAtPoint(sndMissile, transform.position);
		
		yield return new WaitForSeconds(4f);
		
		canFire = true;
		
	}
}
