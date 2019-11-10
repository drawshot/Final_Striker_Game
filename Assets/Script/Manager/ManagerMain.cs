using UnityEngine;
using System.Collections;

public class ManagerMain : MonoBehaviour {
	
		
		public GameObject StartGame;
		public GameObject Quit;
		public AudioClip BGM;
		public GameObject FadeOut;
		public GameObject Button;

	void Start(){
		AudioSource.PlayClipAtPoint(BGM, transform.position);
		Button.SetActive(true);
	}
	
		public void OnClick(GameObject obj){
			if (obj.tag == "PlayGame") {
			StartCoroutine ("delay");
			}
			else if (obj.tag == "QuitGame") {
				Application.Quit();
			}
		}

	IEnumerator delay()
	{
		yield return new WaitForSeconds (0.5f);
		Button.SetActive(false);
		Instantiate (FadeOut);
		yield return new WaitForSeconds (1f);
		Application.LoadLevel("Main");
		
	}
}