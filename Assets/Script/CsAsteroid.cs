using UnityEngine;
using System.Collections;

public class CsAsteroid : MonoBehaviour {

	public Transform expSmall;	// 폭파 불꽃 작은 것
	public Transform expBig;	// 폭파 불꽃 큰 것
	public AudioClip sndExp;	// 폭파 사운드
	int speed = 0; 	// 이동 속도
	int rotX = 0;		// 회전 속도
	int rotY = 0;
	int rotZ = 0;
	int HP = 0; 		// 견고함

	void Start () {  	// 운석 초기화
		InitAsteroid();
	}
	
	void Update () {
		float atmMove= Time.deltaTime * speed;	
		transform.Rotate(new Vector3(rotX, rotY, rotZ) * Time.smoothDeltaTime);
		transform.Translate(Vector3.back * atmMove, Space.World);	// Asteroid down
		if(transform.position.z<-15) {		// Asteroid Destroy
			Destroy(gameObject);
		}
	}

	void InitAsteroid(){		// 운석 초기화
		float scaleX = Random.Range(1.5f, 2.5f);		//운석의 크기
		float scaleY = Random.Range(1.5f, 2.5f);
		float scaleZ = Random.Range(1.5f, 2.5f);
		transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
		// 운석의 Color 설정
		float r = Random.Range (0.6f, 1);	// 알파 값으로, 운석의 진하기 설정
		transform.GetComponent<Renderer> ().material.color = new Vector4 (r, 0.8f, 0.8f, 1);
		// 운석의 속도 및 HP 설정
		speed = Random.Range(10, 20);
		HP = Random.Range(1, 5);
		// 운석의 회전속도 설정
		rotX = Random.Range(-90, 90);
		rotY = Random.Range(-90, 90);
		rotZ = Random.Range(-90, 90);
		//운석의 초기 위치
		float x = Random.Range(-28, 28);
		float z = Random.Range(37, 45);
		transform.position = new Vector3(x, 0, z);		
	}
	void HitMissile(Vector3 pos){		//미사일을 맞았을때
		Instantiate(expSmall, pos, Quaternion.identity);		// pos  위치에
		AudioSource.PlayClipAtPoint(sndExp, pos);
		HP--;
//		CsFighter.score += 100;
//		if(HP<=0) {
//			DestroySelf();
//		}
	}
	void DestroySelf(){
		Instantiate(expBig, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(sndExp, transform.position);
		Destroy(gameObject);
//		CsFighter.score += 1000;
	}
}
