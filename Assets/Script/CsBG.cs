using UnityEngine;
using System.Collections;

public class CsBG : MonoBehaviour {

	float speed = 0.2f;
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time * speed;
		transform.GetComponent<Renderer> ().material.mainTextureOffset = 
			new Vector2 (0, -offset);
	}
}
