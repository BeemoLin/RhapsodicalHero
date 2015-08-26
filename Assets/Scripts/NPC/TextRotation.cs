using UnityEngine;
using System.Collections;

public class TextRotation : MonoBehaviour {

	//GameObject player;
	
	void Awake ()
	{
		//player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Camera.main.transform.rotation;
	}
}
