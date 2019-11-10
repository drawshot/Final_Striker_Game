using UnityEngine;
using System.Collections;

public class SubFight : MonoBehaviour {

	public Transform MagicMissile;

	Transform SpMagic;
	bool canFire = true;
	float lastShootTime = 0;
	int Level;

	void Start(){
		SpMagic = transform.Find ("SpMagic");
	}
	void Update(){
		Level = CsFighter.Fighter.Level;
		if (Level >= 1) {
			ShootMissile ();
		}
	}

	void ShootMissile(){
		if (canFire == true) {
			if (Time.time > lastShootTime + 3.0f) {
				lastShootTime = Time.time;
				StartCoroutine ("MakeMagic");
			}
		}
	}

	IEnumerator MakeMagic(){

		canFire = false;
		
		Instantiate (MagicMissile, SpMagic.position, Quaternion.identity);
		
		yield return new WaitForSeconds (0.2f);
		canFire = true;
	}
}