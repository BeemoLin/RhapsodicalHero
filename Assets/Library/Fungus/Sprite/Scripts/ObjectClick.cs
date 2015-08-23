using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ObjectClick : MonoBehaviour {
	[Tooltip("Is object clicking enabled")]
	public bool clickEnabled = true;
	public string ChangeToScene = "N/A";
	public Vector3 TP;

	void OnMouseDown()
	{
		Debug.Log (clickEnabled);
		if (!clickEnabled)
		{
			return;
		}
		Object ply = GameObject.Find("Angus");
		Object cam = GameObject.Find("Main Camera");
		Application.LoadLevel(ChangeToScene);
		DontDestroyOnLoad(ply);
		DontDestroyOnLoad(cam);

}

void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			clickEnabled = true;
			
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player") {
			clickEnabled = false;
		}
	}
	
	
	
}