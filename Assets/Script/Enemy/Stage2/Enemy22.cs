using UnityEngine;
using System.Collections;

public class Enemy22 : MonoBehaviour {

	public Transform expSmall;  // 폭파 불꽃 작은 것
	public Transform expBig;    // 폭파 불꽃 큰 것
	public AudioClip sndExp;	// 폭파 사운드
	public Transform missile;
	Transform spPoint;
	
	int speed = 0;
	int speed1 = 0;
	int HP = 0;
	
	bool canFire = true;
	
	
	void Start () {
		InitEnemy();
		spPoint = transform.Find ("spPoint");
		//transform.rotation = Quaternion.Euler(new Vector3(90, 60, 0));

	}
	
	
	void Update () {
		float atmMove = Time.deltaTime * speed;
		float atmMove1 = Time.deltaTime * speed1;
		transform.Translate(Vector3.down * atmMove1);
		transform.Translate(Vector3.right * atmMove);
		if (transform.position.z < -15)
		{      
			Destroy(gameObject);
		}
		
		ShootEnemyMissile();
	}
	
	void InitEnemy()
	{
		speed = 3;
		speed1 = 6;
		HP = 3;
		
		float x = Random.Range(27, 29);
		float z = Random.Range(10, 25);
		float y = Random.Range (0, 1);
		transform.position = new Vector3(x, y, z);
	}
	
	void HitMissile(Vector3 pos)
	{       //미사일을 맞았을때
		Instantiate(expSmall, pos, Quaternion.identity);        // pos  위치에
		AudioSource.PlayClipAtPoint(sndExp, pos);
		HP--;
		Manager.manager.Score += 100;
		if (HP <= 0)
		{
			DestroySelf();
		}
	}
	void HitBomb(Vector3 pos)
	{
		Instantiate (expSmall, pos, Quaternion.identity);
		HP -= 80;
		if (HP <= 0) {
			DestroySelf ();
		}
	}
	
	void DestroySelf()
	{
		Instantiate(expBig, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(sndExp, transform.position);
		Destroy(gameObject);
		Manager.manager.Score += 500;
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
		
	//	Instantiate(missile, spPoint.position, Quaternion.identity);
		Instantiate (missile, spPoint.position, Quaternion.Euler (0, 60, 0));
		
		yield return new WaitForSeconds(2f);
		
		canFire = true;
		
	}
	IEnumerator MakeEnemyMissile2()
	{
		canFire = false;
		
	//	Instantiate(missile, spPoint.position, Quaternion.identity);
		Instantiate (missile, spPoint.position, Quaternion.Euler (0, 60, 0));
		//AudioSource.PlayClipAtPoint(sndMissile, transform.position);
		
		yield return new WaitForSeconds(3f);
		
		canFire = true;
		
	}
	IEnumerator MakeEnemyMissile3()
	{
		canFire = false;
		
	//	Instantiate(missile, spPoint.position, Quaternion.identity);
		Instantiate (missile, spPoint.position, Quaternion.Euler (0, 60, 0));
		//AudioSource.PlayClipAtPoint(sndMissile, transform.position);
		
		yield return new WaitForSeconds(4f);
		
		canFire = true;
		
	}
}