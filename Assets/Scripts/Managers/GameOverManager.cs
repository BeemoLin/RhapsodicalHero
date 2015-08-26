using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay = 5f;


    Animator anim;
	float restartTimer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;
			
			if (restartTimer >= restartDelay) {
				Application.LoadLevel(Application.loadedLevel);
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
