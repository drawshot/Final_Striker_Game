using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour
{
	
	public Text txtScore;
	public Text txtBomb;
	public Text txtCool;
    public static Manager manager ;
    public bool ready = true;
    public GameObject Enemy;
    public GameObject EnemyRed;
	public GameObject EnemyAll;
	public GameObject Enemy2;
	public GameObject Enemy21;
	public GameObject Enemy22;
	public GameObject Enemy31;
	public GameObject MiddleBoss;
	public GameObject MiddleBoss2;
	public GameObject Boss;
	public GameObject Boss2;
	public GameObject BombButton;
	public GameObject SkillButton;
	public GameObject ReStartButton;
	public GameObject MainButton;
	public GameObject OptionPlane;
	public GameObject txtOption;
	public GameObject Bomb;
	public GameObject Coll;
	public GameObject BG1;
	public GameObject BG2;
	public GameObject FadeOut;
	public AudioClip ThunderBomb;
//	public AudioClip BGM;



	public int Score = 0;
	public float Cool = 0;
	public int BombCount;
	public float count;
	public double Stage = 1;
	public bool Skill = false;
	public int SkillCount = 1;
	float Cooltime;
	int Level;

    void Start()
    {
        manager = this;
		OptionPlane.SetActive(false);
		txtOption.SetActive(false);
		ReStartButton.SetActive (false);
		MainButton.SetActive (false);

		Bomb.SetActive (false);
		Coll.SetActive (false);
		BombCount = 2;
		BG1.SetActive (true);
		BG2.SetActive (false);
	//	AudioSource.PlayClipAtPoint(BGM, transform.position);

    }

    void Update()
    {
		Level = CsFighter.Fighter.Level;
		if (Stage == 1) {
			MakeEnemy ();
			count++;
		}

			txtScore.text = "Score : " + Score;
			txtBomb.text = "폭탄 : " + BombCount;
			txtCool.text = "" + Cool;
		if (Stage == 2) {
			MakeEnemy2 ();
			count++;
			BG1.SetActive (false);
			BG2.SetActive (true);
		}
		if (Stage == 3) {
			Application.LoadLevel ("Clear");
		}
		if (SkillCount == 1) {
			Cool = 0;
			Cooltime = Time.time;
		}
		if (SkillCount == 0) {
			SkillButton.SetActive (false);
			Cool = Cooltime + 30 - Time.time;
			if (Time.time >= Cooltime + 30) {
				Cooltime = Time.time;
				SkillCount += 1;
				SkillButton.SetActive (true);
			}
		}
    }

    void MakeEnemy()
    {
		if (count < 15999) {
			if (Random.Range (0, 1000) > 990) {
				Instantiate (Enemy);
				if(Random.Range(0,10) > 5){
					Instantiate(Enemy2);
				}
			}
		}
		if (count == 2000 || count == 5000 || count == 7000 || count == 10000 || count == 13000) {
			Instantiate (EnemyRed);
		}
		if (count == 2000) {
			Instantiate (Enemy);
			Instantiate (Enemy);
			Instantiate (Enemy);
			Instantiate (Enemy);
			Instantiate (Enemy);
			Instantiate (Enemy);
			Instantiate (Enemy);
		}
		if (count == 8000) {
			MiddlebossSpawn ();
		}
		if (count == 16000) {
			BossSpawn();
		}
    }

	void MakeEnemy2()
	{
		if (count > 300 && count < 15999) {
			if (Random.Range (0, 1000) > 990) {
				Instantiate (Enemy);
				if (Random.Range(0,1000) > 600){
					Instantiate(Enemy2);
				}
				if (Random.Range(0, 1000) > 600)
				{
					Instantiate(Enemy21);
				}
				if (Random.Range (0, 1000) > 800)
				{
					Instantiate (Enemy22);
				}
			}
		}
		if (count == 5000 || count == 7000 || count == 10000 || count == 13000) {
			Instantiate (EnemyRed);
		}
		if (count == 2000) {
			Instantiate (EnemyRed);
		}
		if (count == 8000) {
			Middle2bossSpawn ();
		}
		if (count == 16000) {
			Boss2Spawn();
		}
	}

	void MiddlebossSpawn(){
		Instantiate (MiddleBoss);
	}

	void Middle2bossSpawn(){
		Instantiate (MiddleBoss2);
	}
	
	void BossSpawn(){
		Instantiate (Boss);
	}
	void Boss2Spawn(){
		Instantiate (Boss2);
	}

	public void OnClick(GameObject obj){
		if (Level > 0) {
			if (obj.tag == "BombButton") {
				if (BombCount > 0) {

					StartCoroutine ("MakeBomb");
			
				}
			}
			if (obj.tag == "SkillButton") {
				if (SkillCount > 0) {
					StartCoroutine ("MakeSkill");
				}
			}
		}
		if (obj.tag == "PAUSE") {
			Time.timeScale = 0f;
			OptionPlane.SetActive(true);
			txtOption.SetActive(true);
			ReStartButton.SetActive (true);
			MainButton.SetActive (true);
		}
		if (obj.tag == "RESTART") {
			Time.timeScale = 1f;
			OptionPlane.SetActive(false);
			txtOption.SetActive(false);
			ReStartButton.SetActive (false);
			MainButton.SetActive (false);
		}
		if (obj.tag == "Main") {
			Application.LoadLevel ("Title");
		}
	}

	IEnumerator MakeBomb(){
		Bomb.SetActive (true);
		Coll.SetActive (true);
		BombCount -= 1;
		AudioSource.PlayClipAtPoint (ThunderBomb, transform.position);

		yield return new WaitForSeconds(0.2f);
		Bomb.SetActive (false);
		yield return new WaitForSeconds(0.2f);
		Bomb.SetActive (true);
		yield return new WaitForSeconds(0.2f);
		Bomb.SetActive (false);
		Coll.SetActive (false);

	}

	IEnumerator MakeSkill(){
		Skill = true;
		SkillCount -= 1;

		yield return new WaitForSeconds(5f);

		Skill = false;

	}
}







