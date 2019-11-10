using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndManager : MonoBehaviour {

	public GameObject Replay;
	public GameObject Quit;
	public Text txtEndScore;
	public Text txtBestScore;
	static int EndScore;
	public int BestScore;
	public static EndManager manager;

	void Start(){
		manager = this;
	}
	void Update()
	{
		EndScore = Manager.manager.Score;
		txtEndScore.text = "Score : " + EndScore;
		//txtBestScore.text = "Best : " + BestScore;
		
		txtBestScore.text = "Best : " + PlayerPrefs.GetInt("BestScore").ToString();
		//if (EndScore >= BestScore) {
	//		BestScore = EndScore;
	//	}
		if (EndScore > PlayerPrefs.GetInt("BestScore"))
		{
			PlayerPrefs.SetInt("BestScore", EndScore);
		}
	}
	public void OnClick(GameObject obj){
		if (obj.tag == "Menu") {
			Application.LoadLevel ("Title");
		}
		else if (obj.tag == "Main") {
			Application.LoadLevel ("Main");
		}
	}
}