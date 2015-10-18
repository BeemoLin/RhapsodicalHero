using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class LevelManager : MonoBehaviour {

	[Tooltip("Is object clicking enabled")]
	public bool clickEnabled = true;
	public string ChangeToScene = "N/A";
	public Vector3 TP;
	public GameObject player;
	public GameObject cam;
	public GameObject hud;

	void Start ()
	{
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");
		}

		if (cam == null) {
			cam = GameObject.FindGameObjectWithTag ("MainCamera");
		}

		if (hud == null) {
			hud = GameObject.FindGameObjectWithTag ("HUD");
		}

		string levelName = Application.loadedLevelName;

		if (levelName.Equals("Initial")) {
			ChangeTo (ChangeToScene);
		}
	}

	void OnMouseDown()
	{
		if (!clickEnabled)
		{
			return;
		}

		ChangeTo (ChangeToScene);
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

	void ChangeTo(string Scene) {
		Application.LoadLevel(Scene);
		DontDestroyOnLoad(player);
		DontDestroyOnLoad(cam);
		DontDestroyOnLoad(hud);

		player.transform.position = TP;
	}
	
	
}