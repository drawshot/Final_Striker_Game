using UnityEngine;
using System.Collections;

public class Boss2 : MonoBehaviour {

	public Transform expSmall;  // 폭파 불꽃 작은 것
	public Transform expBig;    // 폭파 불꽃 큰 것
	//  public AudioClip sndExp;	// 폭파 사운드
	public GameObject missile1;
	public GameObject missile2;
	public AudioClip sndExp;
	
	public Transform spMiddle;
	public Transform spPoint;
	public Transform spLeft1;
	public Transform spLeft2;
	public Transform spRight1;
	public Transform spRight2;
	public GameObject Enemy;
	public GameObject Item;
	public GameObject Item2;
	
	float lastShootTime;
	public int patternNum;
	
	float speed = 0;
	int HP = 0;
	int move = 1;
	float moveSpeed = 0.5f;
	bool CanFire = true;
	
	void Start () {
		gameObject.transform.tag = "Enemy";
		InitBoss();
		Enemy.SetActive(true);
		Item.SetActive(false);
		Item2.SetActive (false);
		
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
		HP = 550;
		
		float z = Random.Range(38, 40);
		transform.position = new Vector3(0, 0, z);
	}
	
	void BossMove(){
		if (transform.position.z > 13.6) {
			float atmMove = Time.deltaTime * speed;
			transform.Translate (Vector3.back * atmMove);

			for (int i=0; i<10; i++) {
				transform.Translate (Vector3.right * Time.deltaTime * move* moveSpeed);
				if (transform.position.x >= 18) {
					move = -1;
				} else if (transform.position.x <= -18) {
					move = 1;
				}
			}
		}
	}
	
	
	void attackPattern(){
		if (Time.time > lastShootTime + 4.0f) {
			lastShootTime = Time.time;
			patternNum = Random.Range (1, 5);
			StartCoroutine (attack (patternNum));
		}
	}
	
	IEnumerator attack(int p){    
		if (p == 1) {

				Instantiate (missile1, spPoint.transform.position, spPoint.transform.rotation);
				Instantiate (missile1, spPoint.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile1, spPoint.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile1, spLeft2.transform.position, spLeft2.transform.rotation);
				Instantiate (missile1, spLeft2.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile1, spLeft2.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile1, spRight2.transform.position, spRight2.transform.rotation);
				Instantiate (missile1, spRight2.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile1, spRight2.transform.position, Quaternion.Euler (0, -35, 0));
				yield return new WaitForSeconds (0.3f);
			}            

		if (p == 2) {
			for (int i=0; i<5; i++) {
				Instantiate (missile1, spMiddle.transform.position, spMiddle.transform.rotation);
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, 15, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, -15, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, 30, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, -30, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, 45, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, -45, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, 60, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, -60, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, 75, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, -75, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, 90, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, -90, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, 105, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, -105, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, 120, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, -120, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, 135, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, -135, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, 150, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, -150, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, 165, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, -165, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, 180, 0));
				Instantiate (missile1, spMiddle.transform.position, Quaternion.Euler (0, -180, 0));
				yield return new WaitForSeconds (0.3f);
			}
		}
		if (p == 3) {
			for (int i=0; i<8; i++) {
				Instantiate (missile2, spPoint.transform.position, spPoint.transform.rotation);
				Instantiate (missile2, spPoint.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile2, spPoint.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile2, spLeft2.transform.position, spLeft2.transform.rotation);
				Instantiate (missile2, spLeft2.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile2, spLeft2.transform.position, Quaternion.Euler (0, -35, 0));
				Instantiate (missile2, spRight2.transform.position, spRight2.transform.rotation);
				Instantiate (missile2, spRight2.transform.position, Quaternion.Euler (0, 35, 0));
				Instantiate (missile2, spRight2.transform.position, Quaternion.Euler (0, -35, 0));

				
				yield return new WaitForSeconds (0.4f);
			}
		}
		if (p == 4) {
			for (int i=0; i<5; i++) {
				Instantiate (missile1, spLeft1.transform.position, spLeft1.transform.rotation);
				Instantiate (missile1, spLeft1.transform.position, Quaternion.Euler (0, 15, 0));
				Instantiate (missile1, spLeft1.transform.position, Quaternion.Euler (0, -15, 0));
				Instantiate (missile1, spLeft1.transform.position, Quaternion.Euler (0, 30, 0));
				Instantiate (missile1, spLeft1.transform.position, Quaternion.Euler (0, -30, 0));
				Instantiate (missile1, spLeft1.transform.position, Quaternion.Euler (0, 45, 0));
				Instantiate (missile1, spLeft1.transform.position, Quaternion.Euler (0, -45, 0));
				Instantiate (missile1, spLeft1.transform.position, Quaternion.Euler (0, 60, 0));
				Instantiate (missile1, spLeft1.transform.position, Quaternion.Euler (0, -60, 0));
				Instantiate (missile1, spLeft1.transform.position, Quaternion.Euler (0, 75, 0));
				Instantiate (missile1, spLeft1.transform.position, Quaternion.Euler (0, -75, 0));
				Instantiate (missile1, spRight1.transform.position, spRight1.transform.rotation);
				Instantiate (missile1, spRight1.transform.position, Quaternion.Euler (0, 15, 0));
				Instantiate (missile1, spRight1.transform.position, Quaternion.Euler (0, -15, 0));
				Instantiate (missile1, spRight1.transform.position, Quaternion.Euler (0, 30, 0));
				Instantiate (missile1, spRight1.transform.position, Quaternion.Euler (0, -30, 0));
				Instantiate (missile1, spRight1.transform.position, Quaternion.Euler (0, 45, 0));
				Instantiate (missile1, spRight1.transform.position, Quaternion.Euler (0, -45, 0));
				Instantiate (missile1, spRight1.transform.position, Quaternion.Euler (0, 60, 0));
				Instantiate (missile1, spRight1.transform.position, Quaternion.Euler (0, -60, 0));
				Instantiate (missile1, spRight1.transform.position, Quaternion.Euler (0, 75, 0));
				Instantiate (missile1, spRight1.transform.position, Quaternion.Euler (0, -75, 0));
				Instantiate (missile1, spLeft2.transform.position, spLeft2.transform.rotation);
				Instantiate (missile1, spLeft2.transform.position, Quaternion.Euler (0, 15, 0));
				Instantiate (missile1, spLeft2.transform.position, Quaternion.Euler (0, -15, 0));
				Instantiate (missile1, spLeft2.transform.position, Quaternion.Euler (0, 30, 0));
				Instantiate (missile1, spLeft2.transform.position, Quaternion.Euler (0, -30, 0));
				Instantiate (missile1, spLeft2.transform.position, Quaternion.Euler (0, 45, 0));
				Instantiate (missile1, spLeft2.transform.position, Quaternion.Euler (0, -45, 0));
				Instantiate (missile1, spLeft2.transform.position, Quaternion.Euler (0, 60, 0));
				Instantiate (missile1, spLeft2.transform.position, Quaternion.Euler (0, -60, 0));
				Instantiate (missile1, spLeft2.transform.position, Quaternion.Euler (0, 75, 0));
				Instantiate (missile1, spLeft2.transform.position, Quaternion.Euler (0, -75, 0));
				Instantiate (missile1, spRight2.transform.position, spRight2.transform.rotation);
				Instantiate (missile1, spRight2.transform.position, Quaternion.Euler (0, 15, 0));
				Instantiate (missile1, spRight2.transform.position, Quaternion.Euler (0, -15, 0));
				Instantiate (missile1, spRight2.transform.position, Quaternion.Euler (0, 30, 0));
				Instantiate (missile1, spRight2.transform.position, Quaternion.Euler (0, -30, 0));
				Instantiate (missile1, spRight2.transform.position, Quaternion.Euler (0, 45, 0));
				Instantiate (missile1, spRight2.transform.position, Quaternion.Euler (0, -45, 0));
				Instantiate (missile1, spRight2.transform.position, Quaternion.Euler (0, 60, 0));
				Instantiate (missile1, spRight2.transform.position, Quaternion.Euler (0, -60, 0));
				Instantiate (missile1, spRight2.transform.position, Quaternion.Euler (0, 75, 0));
				Instantiate (missile1, spRight2.transform.position, Quaternion.Euler (0, -75, 0));
				yield return new WaitForSeconds (0.3f);
			}
		}    
	}
	
	void HitMissile(Vector3 pos)
	{       //미사일을 맞았을때
		Instantiate(expSmall, pos, Quaternion.identity);        // pos  위치에
		AudioSource.PlayClipAtPoint(sndExp, pos);
		HP--;
		Manager.manager.Score += 200;
		if (HP <= 0)
		{
			DestroySelf ();
			CanFire = false;
			this.gameObject.GetComponent<SphereCollider>().enabled=false;
			Item.SetActive(true);
			Item2.SetActive(true);
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
			Item2.SetActive(true);
			Target.target.TargetFire = 0;
		}
	}
	
	
	void DestroySelf()
	{
		gameObject.transform.tag = "Untagged";
		Instantiate(expBig, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(sndExp, transform.position);
		Destroy(Enemy);
		Manager.manager.Score += 10000;
		StartCoroutine ("delay");
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