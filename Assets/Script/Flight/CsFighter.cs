using UnityEngine;
using System.Collections;

public class Boundary
{
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;
}

public class CsFighter : MonoBehaviour {

    public Transform Enemy;
    public Transform missile;
	public Object missileSkill;

    public Transform expBig;
	public Transform expSmall;
    public AudioClip sndMissile;

	Transform pos1;
	Transform pos2;
	Transform pos3;

 	GameObject MainFire;
	public static CsFighter Fighter;
	double Stage;


    public bool canFire = true;
    bool isDead = false;
	
	private Vector3 _offset;
	private Camera _mainCamera;
	public Boundary boundary;


    public int Level = 1;
	int Bomb1;
  //  static public int score = 0;

	float speed = 20f;  // 좌우 이동속도
	float fw = Screen.width * 0.08f; // 전투기의 폭
	float fh = Screen.height * 0.04f;

	int dire;
	int dire1;
	float speedRot = 30f;
	float speedSide = 30f;
	float speedSide1 = 40f;

	void Awake(){
		//DontDestroyOnLoad (gameObject);
	}

    void Start ()
    {

	//	_mainCamera = Camera.main;
		Fighter = this;
     //   HP = 10;
     //   score = 0;
        isDead = false;

		pos1 = transform.Find ("Fire Pos 1");
		pos2 = transform.Find ("Fire Pos 2");
		pos3 = transform.Find ("Fire Pos 3");

//		pos4 = transform.Find ("Fire Pos 4");
//		pos5 = transform.Find ("Fire Pos 5");
//		pos6 = transform.Find ("Fire Pos 6");
//		pos7 = transform.Find ("Fire Pos 7");

		//MainFire = transform.Find ("MainFire").gameObject;
		//MainFire.SetActive (false);
    }

	void Update ()
    {
	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		Vector3 touchPos = Input.mousePosition;
	//		touchPos.z = 0f;
	//
	//		_offset = transform.position - touchPos;
	//	}
	//	if (Input.GetMouseButton(0))
	//	{
	//		Vector3 targetPos = Input.mousePosition;
	//		targetPos.x = Mathf.Clamp(targetPos.x + _offset.x, boundary.xMin, boundary.xMax);
	//		targetPos.y = Mathf.Clamp(targetPos.y + _offset.y, boundary.yMin, boundary.yMax);
	//		targetPos.z = 0f;
	//
	//		transform.position = targetPos;
	//	}
		if (Input.GetMouseButton (0)) {
			Vector3 WorldPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 10));
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 10;
			Vector3 MWPos = Camera.main.ScreenToWorldPoint (mousePos);
			if (MWPos.x <= transform.position.x - transform.localScale.x / 5 && 
				transform.position.x >= -WorldPosition.x + transform.localScale.x / 2) {
				transform.Translate (Vector3.left * Time.deltaTime * speedSide, Space.World);
				dire = -1;
			} else if (MWPos.x >= transform.position.x + transform.localScale.x / 5 && 
				transform.position.x <= WorldPosition.x - transform.localScale.x / 2) {
				dire = 1;
				transform.Translate (Vector3.right * Time.deltaTime * speedSide, Space.World);
			}
	
			if (MWPos.z <= transform.position.z - transform.localScale.z / 5 - 10 && 
				transform.position.y >= -WorldPosition.y + transform.localScale.y / 2 ) {
				transform.Translate (Vector3.back * Time.deltaTime * speedSide1, Space.World);
				dire1 = -1;
			} else if (MWPos.z >= transform.position.z + transform.localScale.z /5 - 10 && 
				transform.position.y <= WorldPosition.y - transform.localScale.y / 2 ) {
				dire1 = 1;
				transform.Translate (Vector3.forward * Time.deltaTime * speedSide1, Space.World);
			}
		}
		Vector3 ang = transform.eulerAngles;
		if(ang.z > 180)
			ang.z -= 360;
		ang.z = Mathf.Clamp (ang.z, -15, 15);
		transform.eulerAngles = ang;

		Stage = Manager.manager.Stage;
        if (isDead) return;

		if (Stage == 1 || Stage == 2 || Stage == 3) {
			if (Level > 0) {
				MoveFighter ();
				ShootMissile ();
			}
		}
		Bomb1 = Manager.manager.BombCount;
	}

	void MoveFighter(){
		float amtMove= speed * Time.deltaTime;
		float key = Input.GetAxis("Horizontal");
		float key1 = Input.GetAxis ("Vertical");
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		if ((key < 0 && pos.x > fw) || (key > 0 && pos.x < Screen.width - fw)){
			transform.Translate(Vector3.right * amtMove * key, Space.World);
		}  // 화면 안에서 전투기 이동
		if ((key1 < 0 && pos.y > fh) || (key1 > 0 && pos.y < Screen.height - fh)) {
			transform.Translate (Vector3.forward * amtMove * key1, Space.World);
		}
		transform.eulerAngles = new Vector3(0, 0, -key * 20); // 전투기 회정
	}

    void ShootMissile()
    {
      //  if(Input.GetButton("Fire1") && canFire)
      //  {
		if (canFire == true) {
			if ( Manager.manager.Skill == false){
				if (Level == 1) {
					StartCoroutine ("MakeMissile1");
				}
				if (Level == 2) {
					StartCoroutine ("MakeMissile2");
				}
				if (Level == 3) {
					StartCoroutine ("MakeMissile3");
				}
				if (Level == 4) {
					StartCoroutine ("MakeMissile4");
				}
			}
			if ( Manager.manager.Skill == true){
				StartCoroutine("MakeSkill");
			}
		}
    //    }
    }

    IEnumerator MakeMissile1()
    {
        
			canFire = false;

			Instantiate (missile, pos1.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint (sndMissile, transform.position);

			//	MainFire.SetActive (true);

			yield return new WaitForSeconds (0.2f);
			canFire = true;
	//	MainFire.SetActive (false);
    }
	IEnumerator MakeMissile2()
	{
			canFire = false;
		
			Instantiate (missile, pos1.position, Quaternion.identity);
			Instantiate (missile, pos2.position, Quaternion.identity);
			Instantiate (missile, pos3.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint (sndMissile, transform.position);
		
			//	MainFire.SetActive (true);
		
			yield return new WaitForSeconds (0.2f);
			canFire = true;
	}
	IEnumerator MakeMissile3()
	{
			canFire = false;
		
			Instantiate (missile, pos1.position, Quaternion.identity);
			Instantiate (missile, pos2.position, Quaternion.identity);
			Instantiate (missile, pos3.position, Quaternion.identity);
			Instantiate (missile, pos2.position, Quaternion.Euler (0, 20, 0));
			Instantiate (missile, pos3.position, Quaternion.Euler (0, -20, 0));
			//Instantiate(missile, pos4.position, pos4.rotation);
			//Instantiate(missile, pos5.position, pos5.rotation);
			AudioSource.PlayClipAtPoint (sndMissile, transform.position);
		
			//	MainFire.SetActive (true);
		
			yield return new WaitForSeconds (0.2f);
			canFire = true;
		//	MainFire.SetActive (false);
	}
	IEnumerator MakeMissile4()
	{
			canFire = false;
		
			Instantiate (missile, pos1.position, Quaternion.identity);
			Instantiate (missile, pos2.position, Quaternion.identity);
			Instantiate (missile, pos3.position, Quaternion.identity);
			Instantiate (missile, pos2.position, Quaternion.Euler (0, 20, 0));
			Instantiate (missile, pos3.position, Quaternion.Euler (0, -20, 0));
			Instantiate (missile, pos2.position, Quaternion.Euler (0, 30, 0));
			Instantiate (missile, pos3.position, Quaternion.Euler (0, -30, 0));
			//Instantiate(missile, pos4.position, pos4.rotation);
			//Instantiate(missile, pos5.position, pos5.rotation);
			//Instantiate(missile, pos6.position, pos6.rotation);
			//Instantiate(missile, pos7.position, pos7.rotation);
			AudioSource.PlayClipAtPoint (sndMissile, transform.position);
		
			//	MainFire.SetActive (true);
		
			yield return new WaitForSeconds (0.2f);
			canFire = true;
		//	MainFire.SetActive (false);
	}

	IEnumerator MakeSkill()
	{
		canFire = false;
		
		Instantiate (missileSkill, pos1.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint (sndMissile, transform.position);
		
		//	MainFire.SetActive (true);
		
		yield return new WaitForSeconds (0.008f);
		canFire = true;
		//	MainFire.SetActive (false);
	}



	//void MakeEnemy (){
	//  if (Random.Range (0, 1000) > 980) {
	//		Instantiate (Enemy);
	//	}
	//}

	void HitEnemyMissile(Vector3 pos)
	{       //미사일을 맞았을때
		Instantiate(expSmall, pos, Quaternion.identity);        // pos  위치에
		//       AudioSource.PlayClipAtPoint(sndExp, pos);
		Level--;
		//   CsFighter.score += 100;
		if (Level <= 0)
		{
			DestroyFighter();
		}
	}
	
	void OnTriggerEnter(Collider coll){
		if(coll.transform.tag == "Enemy"){
			coll.SendMessage("DestroySelf", SendMessageOptions.DontRequireReceiver); 	
			Level--;
			if(Level<=0) {
				Level = 0;
				StartCoroutine("DestroyFighter");
			}
	//	}
	//	if (coll.transform.tag == "Boss") {
	//		Level--;
	//		if (Level <= 0) {
	//			Level = 0;
	//			StartCoroutine ("DestroyFighter");
	//		}
		}
		if (coll.transform.tag == "EnemyMissile") {
			Instantiate(expSmall, transform.position, Quaternion.identity); 
			coll.SendMessage ("DestroySelf", SendMessageOptions.DontRequireReceiver);
			Level--;
			if (Level <= 0) {
				Level = 0;
				StartCoroutine ("DestroyFighter");
			}
		}
        if ( coll.transform.tag == "Power")
        {
			if (Level <4)
			{
            Level++;
			}
			else {
				Manager.manager.Score += 2000;
			}
			coll.SendMessage ("DestroySelf", SendMessageOptions.DontRequireReceiver);
        }
		if ( coll.transform.tag == "Bomb")
		{
			if ( Bomb1 < 3)
			{
			Manager.manager.BombCount += 1;
			}
			else{
			Manager.manager.Score += 2000;
			}
			coll.SendMessage ("DestroySelf", SendMessageOptions.DontRequireReceiver);
		}
    }
	IEnumerator DestroyFighter(){
     	Instantiate(expBig, transform.position, Quaternion.identity);	
		transform.position = new Vector3(0, -10, -20);
		yield return new WaitForSeconds(3.0f);		// 1초 대기	
		isDead = true;
		Application.LoadLevel ("End");
	}
	
	//void OnGUI() {
	//	int w = Screen.width / 2;
	//	int h = Screen.height / 2;
	//
	//	GUI.Label (new Rect (10, 10, 120, 50), "HP : " + HP);
	//	GUI.Label (new Rect (w - 50, 10, 120, 50), "Score : " + score);
	//
	//	if (!isDead)
	//		return;
	//
	//	if (GUI.Button (new Rect (w - 60, h - 50, 120, 50), "Play Game")) {
	//		Application.LoadLevel ("MainGame");
	//	}
	//	if (GUI.Button (new Rect (w - 60, h + 50, 120, 50), "Quit Game")) {
	//		Application.Quit ();
	//	}
	//}
}
