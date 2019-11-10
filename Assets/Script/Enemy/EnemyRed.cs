using UnityEngine;
using System.Collections;

public class EnemyRed : MonoBehaviour {

    public Transform expSmall;  // 폭파 불꽃 작은 것
    public Transform expBig;    // 폭파 불꽃 큰 것
                                //  public AudioClip sndExp;	// 폭파 사운드
    public Transform missile;
    Transform spPoint;
	public AudioClip sndExp;

    int speed = 0;
    int HP = 0;

    bool canFire = true;
    public GameObject Enemy;
    public GameObject Item;


    void Start()
    {
		gameObject.transform.tag = "Enemy";
        InitEnemy();
        spPoint = transform.Find("spPoint");
        Enemy.SetActive(true);
        Item.SetActive(false);
    }


    void Update()
    {
        float atmMove = Time.deltaTime * speed;
        transform.Translate(Vector3.back * atmMove);
        if (transform.position.z < -15)
        {
            Destroy(gameObject);
        }
		if (HP > 0) {
			ShootEnemyMissile ();
		}
    }

    void InitEnemy()
    {
        speed = Random.Range(3, 6);
        HP = 3;

        float x = Random.Range(-23, 23);
        float z = Random.Range(30, 33);
        transform.position = new Vector3(x, 0, z);
    }

    void HitMissile(Vector3 pos)
    {       //미사일을 맞았을때
        Instantiate(expSmall, pos, Quaternion.identity);        // pos  위치에
		AudioSource.PlayClipAtPoint(sndExp, transform.position);                                                       //       AudioSource.PlayClipAtPoint(sndExp, pos);
        HP--;
		Manager.manager.Score += 200;
        if (HP <= 0)
        {
			canFire = false;
			DestroySelf();
			this.gameObject.GetComponent<SphereCollider>().enabled=false;
            Item.SetActive(true);
          
        }
    }

    void DestroySelf()
    {
		gameObject.transform.tag = "Untagged";
		Manager.manager.Score += 1000;
        Instantiate(expBig, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(sndExp, transform.position);
        Destroy(Enemy);

        //  CsFighter.score += 1000;
    }

	void HitBomb(Vector3 pos)
	{
		DestroySelf ();
		canFire = false;
		HP = 0;
		Manager.manager.Score += 200;
		Instantiate (expSmall, pos, Quaternion.identity);
		this.gameObject.GetComponent<SphereCollider> ().enabled = false;
		Item.SetActive (true);
	}
	void DestroyItem()
	{
		Destroy (Item);
	}

    void ShootEnemyMissile()
    {
		if (canFire == true) {
			int ran = Random.Range (1, 4);
			if (ran == 1) {
				if (canFire == true) {
					StartCoroutine ("MakeEnemyMissile1");
				}
			} else if (ran == 2) {
				if (canFire == true) {
					StartCoroutine ("MakeEnemyMissile2");
				}
			} else if (ran == 3) {
				if (canFire == true) {
					StartCoroutine ("MakeEnemyMissile3");
				}
			}
		}
    }

    IEnumerator MakeEnemyMissile1()
    {
        canFire = false;

        Instantiate(missile, spPoint.position, Quaternion.identity);
        //AudioSource.PlayClipAtPoint(sndMissile, transform.position);

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
