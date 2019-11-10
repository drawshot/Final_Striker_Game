using UnityEngine;
using System.Collections;

public class MainBG : MonoBehaviour {

	int rotX;
	int rotY;
	int rotZ;
	// Use this for initialization
	void Start () {
		transform.Rotate (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 15, 0) * Time.smoothDeltaTime);
	
	}
}
