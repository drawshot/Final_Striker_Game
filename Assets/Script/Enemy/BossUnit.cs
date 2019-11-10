using UnityEngine;
using System.Collections;

public class BossUnit : MonoBehaviour {
	int speed;
	int Hp;
	int move;
	int moveSpeed;
	public Transform expSmall;  
	public Transform expBig; 
	public AudioClip sndExp;

	public GameObject missile;
	public Transform sp1;

	float lastShootTime;

	// Use this for initialization
	void Start () {
		speed = 10;
		Hp = 7;
		moveSpeed = 5;
		int Ran = Random.Range (0, 2);
		if (Ran == 0) {
			move = 1;
		} else if (Ran == 1) {
			move = -1;
		}

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0, 90, 0) * Time.smoothDeltaTime);
		float amtMove = speed * Time.smoothDeltaTime;
		if (transform.position.z > 5) {
			transform.Translate (Vector3.back * amtMove, Space.World);
		}

		transform.Translate (Vector3.right * Time.deltaTime * move * moveSpeed, Space.World);
		if (transform.position.x >= 20) {
			move = -1;
		} else if (transform.position.x <= -20) {
			move = 1;
		}
		if (Time.time > lastShootTime + 2.0f) {
			lastShootTime = Time.time;
			StartCoroutine ("attack");
		}
	}

	IEnumerator attack(){

		Instantiate (missile, sp1.transform.position, sp1.transform.rotation);
		Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, 90, 0));
		Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, 45, 0));
		Instantiate (missile, sp1.transform.position, Quaternion.Euler (0, 17, 0));

		yield return new WaitForSeconds (0.8f);

	}

	void HitMissile(Vector3 pos)
	{       //미사일을 맞았을때
		Instantiate(expSmall, pos, Quaternion.identity);        // pos  위치에
		AudioSource.PlayClipAtPoint(sndExp, pos);
		Hp--;
		Manager.manager.Score += 200;
		if (Hp <= 0)
		{
			DestroySelf ();
		}
	}

	void HitBomb(Vector3 pos)
	{
		Instantiate (expSmall, pos, Quaternion.identity);
		Manager.manager.Score += 200;
		DestroySelf ();
	}

	void DestroySelf()
	{
		Instantiate(expBig, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(sndExp, transform.position);
		Destroy(gameObject);
		Manager.manager.Score += 800;
	}
}
