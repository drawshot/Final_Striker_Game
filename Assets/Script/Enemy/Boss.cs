using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public Transform expSmall;  // 폭파 불꽃 작은 것
	public Transform expBig;    // 폭파 불꽃 큰 것
	//  public AudioClip sndExp;	// 폭파 사운드
	public GameObject missile1;
	public GameObject missile2;
	public GameObject missile3;
	public GameObject missile4;
	public GameObject missile5;
	public AudioClip sndExp;
	
	public Transform sp1;
	public Transform sp2;
	public Transform sp3;
	public Transform sp4;
	public Transform sp5;
	public GameObject Enemy;
	public GameObject Item;
	
	float lastShootTime;
	public int patternNum;
	
	float speed = 0;
	int HP = 0;
	bool CanFire = true;
	
	void Start () {
		gameObject.transform.tag = "Enemy";
		InitBoss();
		Enemy.SetActive(true);
		Item.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		BossMove ();
		if (CanFire == true) {
			attackPattern ();
		}
	}

	void InitBoss()
	{
		speed = 1.5f;
		HP = 400	;

		float z = Random.Range(25, 30);
		transform.position = new Vector3(0, 0, z);
	}
	
	void BossMove(){
		if (transform.position.z > 20) {
			float atmMove = Time.deltaTime * speed;
			transform.Translate (Vector3.back * atmMove);
		}
	}
	
	
	void attackPattern(){
		if (Time.time > lastShootTime + 5.0f) {
			lastShootTime = Time.time;
			patternNum = Random.Range (1, 6);
			StartCoroutine (attack (patternNum));
		}
	}
	
	IEnumerator attack(int p){    
		if (p == 1) {
			for (int i=0; i<5; i++) {
				Instantiate (missile1, sp1.transform.position, sp1.transform.rotation);
				Instantiate (missile1, sp1.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile1, sp1.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile1, sp2.transform.position, sp2.transform.rotation);
				Instantiate (missile1, sp2.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile1, sp2.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile1, sp3.transform.position, sp3.transform.rotation);
				Instantiate (missile1, sp3.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile1, sp3.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile1, sp4.transform.position, sp4.transform.rotation);
				Instantiate (missile1, sp4.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile1, sp4.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile1, sp5.transform.position, sp5.transform.rotation);
				Instantiate (missile1, sp5.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile1, sp5.transform.position, Quaternion.Euler (0, -35, 0));
				yield return new WaitForSeconds (0.2f);
			}            
		}
		if (p == 2) {
			for (int i=0; i<5; i++) {
				Instantiate (missile3, sp4.transform.position, sp1.transform.rotation);
				Instantiate (missile3, sp4.transform.position, Quaternion.Euler (0, 17, 0));
				Instantiate (missile3, sp4.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile3, sp4.transform.position, Quaternion.Euler (0, -17, 0));
				Instantiate (missile3, sp4.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile3, sp5.transform.position, sp2.transform.rotation);
				Instantiate (missile3, sp5.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile3, sp5.transform.position, Quaternion.Euler (0, 17, 0));
				Instantiate (missile3, sp5.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile3, sp5.transform.position, Quaternion.Euler (0, -17, 0));
				yield return new WaitForSeconds (0.4f);
			}
		}
		if (p == 3) {
			for (int i=0; i<5; i++) {
				Instantiate (missile2, sp1.transform.position, sp1.transform.rotation);
				Instantiate (missile1, sp1.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile1, sp1.transform.position, Quaternion.Euler (0, 17, 0));
				Instantiate (missile1, sp1.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile1, sp1.transform.position, Quaternion.Euler (0, -17, 0));
				Instantiate (missile2, sp2.transform.position, sp2.transform.rotation);
				Instantiate (missile2, sp3.transform.position, sp3.transform.rotation);
				Instantiate (missile2, sp4.transform.position, sp4.transform.rotation);
				Instantiate (missile2, sp5.transform.position, sp5.transform.rotation);

				yield return new WaitForSeconds (0.4f);
			}
		}
		if (p == 4) {
			for (int i=0; i<5; i++) {
				Instantiate (missile4, sp1.transform.position, sp1.transform.rotation);
				Instantiate (missile4, sp1.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile4, sp1.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile4, sp4.transform.position, sp4.transform.rotation);
				Instantiate (missile4, sp4.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile4, sp4.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile4, sp5.transform.position, sp5.transform.rotation);
				Instantiate (missile4, sp5.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile4, sp5.transform.position, Quaternion.Euler (0, -35, 0));
				yield return new WaitForSeconds (0.4f);
			}
		}    
		if (p == 5) {
			for (int i=0; i<5; i++) {
				Instantiate (missile5, sp1.transform.position, sp1.transform.rotation);
				Instantiate (missile4, sp1.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile3, sp1.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile5, sp2.transform.position, sp2.transform.rotation);
				Instantiate (missile4, sp2.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile3, sp2.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile5, sp3.transform.position, sp3.transform.rotation);
				Instantiate (missile4, sp3.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile3, sp3.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile5, sp4.transform.position, sp4.transform.rotation);
				Instantiate (missile4, sp4.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile3, sp4.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile5, sp5.transform.position, sp5.transform.rotation);
				Instantiate (missile4, sp5.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile3, sp5.transform.position, Quaternion.Euler (0, -35, 0));
			}
		}
	}
	
	void HitMissile(Vector3 pos)
	{       //미사일을 맞았을때
		Instantiate(expSmall, pos, Quaternion.identity);        // pos  위치에
		AudioSource.PlayClipAtPoint(sndExp, pos);
		HP--;
		Manager.manager.Score += 100;
		if (HP <= 0)
		{
			DestroySelf ();
			CanFire = false;
			this.gameObject.GetComponent<SphereCollider>().enabled=false;
			Item.SetActive(true);
			Target.target.TargetFire = 0;
		}
	}
	void HitBomb(Vector3 pos)
	{
		Instantiate (expSmall, pos, Quaternion.identity);
		HP -= 80;
		if (HP <= 0) {
			DestroySelf ();
			CanFire = false;
			this.gameObject.GetComponent<SphereCollider> ().enabled = false;
			Item.SetActive (true);
			Target.target.TargetFire = 0;
		}
	}
	
	
	void DestroySelf()
	{
		gameObject.transform.tag = "Untagged";
		Instantiate(expBig, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(sndExp, transform.position);
		Destroy(Enemy);
		Manager.manager.Score += 8000;
		StartCoroutine ("delay");
	}
	
	void DestroyItem()
	{
		Destroy (Item);
	}
	IEnumerator delay()
	{
		yield return new WaitForSeconds (5f);
		Instantiate (Manager.manager.FadeOut);
		Manager.manager.Stage += 0.5;
		yield return new WaitForSeconds (1f);
		Manager.manager.Stage += 0.5;
		Manager.manager.count = 0;

	}
	
}