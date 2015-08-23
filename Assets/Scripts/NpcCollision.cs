using UnityEngine;
using System.Collections;
using Fungus;

public class NpcCollision : MonoBehaviour {
	
	public Canvas canvas;
	
	void Start() {
		canvas.enabled = false;
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			canvas.enabled = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player") {
			canvas.enabled = false;
		}
	}
	
}
