using UnityEngine;
using System.Collections;

public class EnemyControll2 : MonoBehaviour {

	public Transform expSmall;  // 폭파 불꽃 작은 것
	public Transform expBig;    // 폭파 불꽃 큰 것
	public AudioClip sndExp;	// 폭파 사운드
	public Transform missile;
	Transform spPoint1;
	Transform spPoint2;
	
	int speed = 0;
	int HP = 0;
	int move = 1;
	int move1 = 5;
	
	bool canFire = true;
	
	
	void Start () {
		InitEnemy();
		spPoint1 = transform.Find ("spPoint1");
		spPoint2 = transform.Find ("spPoint2");
	}
	
	
	void Update () {
		float atmMove = Time.deltaTime * speed;
		transform.Translate(Vector3.down * atmMove);
		transform.Translate (Vector3.right * Time.deltaTime * move * move1);
		if (transform.position.x >= 20) {
			move = -1;
		} else if (transform.position.x <= -20) {
			move = 1;
		}
		if (transform.position.z < -15)
		{      
			Destroy(gameObject);
		}
		
		ShootEnemyMissile();
	}
	
	void InitEnemy()
	{
		speed = Random.Range(5, 7);
		HP = Random.Range(3, 5);
		
		float x = Random.Range(-23, 23);
		float z = Random.Range(30, 33);
		float y = Random.Range (0, 1);
		transform.position = new Vector3(x, y, z);
	}
	
	void HitMissile(Vector3 pos)
	{       //미사일을 맞았을때
		Instantiate(expSmall, pos, Quaternion.identity);        // pos  위치에
		AudioSource.PlayClipAtPoint(sndExp, pos);
		HP--;
		Manager.manager.Score += 150;
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
		Manager.manager.Score += 700;
	}
	
	void ShootEnemyMissile()
	{
		int ran = Random.Range (1, 3);
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
	}
	
	IEnumerator MakeEnemyMissile1()
	{
		canFire = false;
		
		Instantiate(missile, spPoint1.position, Quaternion.identity);
		Instantiate(missile, spPoint2.position, Quaternion.identity);
		
		yield return new WaitForSeconds(2f);
		
		canFire = true;
		
	}
	IEnumerator MakeEnemyMissile2()
	{
		canFire = false;
		
		Instantiate(missile, spPoint1.position, Quaternion.identity);
		Instantiate(missile, spPoint2.position, Quaternion.identity);
		//AudioSource.PlayClipAtPoint(sndMissile, transform.position);
		
		yield return new WaitForSeconds(3f);
		
		canFire = true;
		
	}
}