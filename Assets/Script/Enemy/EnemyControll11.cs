using UnityEngine;
using System.Collections;

public class EnemyControll11 : MonoBehaviour {

	public Transform expSmall;  // 폭파 불꽃 작은 것
	public Transform expBig;    // 폭파 불꽃 큰 것
	public AudioClip sndExp;	// 폭파 사운드
	public Transform missile;
	Transform spPoint;
	
	int speed = 0;
	int HP = 0;
	
	bool canFire = true;
	
	
	void Start () {
		InitEnemy();
		spPoint = transform.Find ("spPoint");
	}
	
	
	void Update () {
		float atmMove = Time.deltaTime * speed;
		transform.Translate(Vector3.back * atmMove);
		if (transform.position.z < -15)
		{      
			Destroy(gameObject);
		}
		
		ShootEnemyMissile();
	}
	
	void InitEnemy()
	{
		speed = Random.Range(5, 10);
		HP = Random.Range(3, 5);
		
		float x = Random.Range(-23, 23);
		float z = Random.Range(37, 43);
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
		
		Instantiate(missile, spPoint.position, Quaternion.identity);
		
		yield return new WaitForSeconds(2f);
		
		canFire = true;
		
	}
	IEnumerator MakeEnemyMissile2()
	{
		canFire = false;
		
		Instantiate(missile, spPoint.position, Quaternion.identity);
		//AudioSource.PlayClipAtPoint(sndMissile, transform.position);
		
		yield return new WaitForSeconds(3f);
		
		canFire = true;
		
	}
	IEnumerator MakeEnemyMissile3()
	{
		canFire = false;
		
		Instantiate(missile, spPoint.position, Quaternion.identity);
		//AudioSource.PlayClipAtPoint(sndMissile, transform.position);
		
		yield return new WaitForSeconds(4f);
		
		canFire = true;
		
	}
}
