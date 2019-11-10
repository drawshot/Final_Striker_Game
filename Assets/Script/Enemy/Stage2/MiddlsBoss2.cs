using UnityEngine;
using System.Collections;

public class MiddlsBoss2 : MonoBehaviour {

	public Transform expSmall;  // 폭파 불꽃 작은 것
	public Transform expBig;    // 폭파 불꽃 큰 것
	public AudioClip sndExp;	// 폭파 사운드
	public GameObject missile;
	
	public Transform sp1;
	public Transform sp2;
	public Transform sp3;
	public GameObject Enemy;
	public GameObject Item;
	
	float lastShootTime;
	public int patternNum;
	
	float speed = 0;
	int move = 1;
	int HP = 0;
	bool CanFire = true;
	
	void Start () {
		gameObject.transform.tag = "Enemy";
		InitMiddleboss();
		Enemy.SetActive(true);
		Item.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		MiddleBossMove ();
		if (CanFire == true) {
			attackPattern ();
		}
	}
	
	
	void InitMiddleboss()
	{
		speed = 1.5f;
		HP = 300	;
		
		float x = Random.Range(-17, 19);
		float z = Random.Range(20, 22);
		transform.position = new Vector3(x, 0, z);
	}
	
	void MiddleBossMove(){
		if (transform.position.z > 17) {
			float atmMove = Time.deltaTime * speed;
			transform.Translate (Vector3.back * atmMove);
		}
		transform.Translate (Vector3.right * Time.deltaTime * move);
		if (transform.position.x >= 18) {
			move = -1;
		} else if (transform.position.x <= -18) {
			move = 1;
		}
	}
	
	
	void attackPattern(){
		if (Time.time > lastShootTime + 5.0f) {
			lastShootTime = Time.time;
			patternNum = Random.Range (1, 4);
			StartCoroutine (attack (patternNum));
		}
	}
	
	IEnumerator attack(int p){    
		if (p == 1) {
			for (int i=0; i<8; i++) {
				Instantiate (missile, sp1.transform.position, sp1.transform.rotation);
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, 30, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, -30, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, 60, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, -60, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, 90, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, -90, 0));
				Instantiate (missile, sp2.transform.position, sp2.transform.rotation);
				Instantiate (missile, sp3.transform.position, sp3.transform.rotation);
				yield return new WaitForSeconds (0.2f);
			}            
		}
		if (p == 2) {
			for (int i=0; i<5; i++) {
				Instantiate (missile, sp1.transform.position, sp1.transform.rotation);
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, 15, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, -15, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, 30, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, -30, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, 45, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, -45, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, 60, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, -60, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, 75, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, -75, 0));
				Instantiate (missile, sp2.transform.position, sp2.transform.rotation);
				Instantiate (missile, sp2.transform.position, Quaternion.Euler (0, 30, 0));
				Instantiate (missile, sp2.transform.position, Quaternion.Euler (0, -30, 0));
				Instantiate (missile, sp2.transform.position, Quaternion.Euler (0, 60, 0));
				Instantiate (missile, sp2.transform.position, Quaternion.Euler (0, -60, 0));
				Instantiate (missile, sp3.transform.position, sp3.transform.rotation);
				Instantiate (missile, sp3.transform.position, Quaternion.Euler (0, 30, 0));
				Instantiate (missile, sp3.transform.position, Quaternion.Euler (0, -30, 0));
				Instantiate (missile, sp3.transform.position, Quaternion.Euler (0, 60, 0));
				Instantiate (missile, sp3.transform.position, Quaternion.Euler (0, -60, 0));
				yield return new WaitForSeconds (0.4f);
			}
		}
		if (p == 3) {
			for (int i=0; i<5; i++) {
				Instantiate (missile, sp1.transform.position, sp1.transform.rotation);
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile, sp2.transform.position, sp2.transform.rotation);
				Instantiate (missile, sp2.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile, sp2.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile, sp3.transform.position, sp3.transform.rotation);
				Instantiate (missile, sp3.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile, sp3.transform.position, Quaternion.Euler (0, -35, 0));
				yield return new WaitForSeconds (0.4f);
			}
		}
	}
	
	void HitMissile(Vector3 pos)
	{       //미사일을 맞았을때
		Instantiate(expSmall, pos, Quaternion.identity);        // pos  위치에
		AudioSource.PlayClipAtPoint(sndExp, pos);
		HP--;
		Manager.manager.Score += 150;
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
		Manager.manager.Score += 5000;
	}
	
	void DestroyItem()
	{
		Destroy (Item);
	}
	
}