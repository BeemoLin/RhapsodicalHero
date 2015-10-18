using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay = 5f;
	public GameObject player;
	public GameObject cam;
	public GameObject hud;

    Animator anim;
	float restartTimer;

    void Awake()
    {
        anim = GetComponent<Animator>();

		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");
		}

		if (cam == null) {
			cam = GameObject.FindGameObjectWithTag ("MainCamera");
		}
		
		if (hud == null) {
			hud = GameObject.FindGameObjectWithTag ("HUD");
		}
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;
			
			if (restartTimer >= restartDelay) {
				Destroy(player);
				Destroy(cam);
				Destroy(hud);
				Application.LoadLevel("Initial");
			}
        }
    }

	public void ChangeToScene() {
		if (Application.loadedLevelName.Equals ("environment")) {
			Application.LoadLevel ("Level02");
		}

		if (Application.loadedLevelName.Equals ("Level02")) {
			Application.LoadLevel ("environment");
		}
	}

	public void ChangeToScene(string sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);
	}
}
