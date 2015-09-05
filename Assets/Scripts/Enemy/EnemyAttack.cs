using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 10;
	
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
	SphereCollider spearCollider;
	float timer;
	bool playGetHit = false;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
		anim = GetComponentInParent<Animator>();
		spearCollider = GetComponent<SphereCollider>();
    }

	void Update() {
		timer += Time.deltaTime;

		if (anim.GetBool ("IsAttack")) {
			spearCollider.enabled = true;
		} else {
			spearCollider.enabled = false;
			if (playGetHit) {
				playGetHit = false;
				HitPlayer();
			}
		}

	}

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
			playGetHit = true;
		}
    }

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playGetHit = false;
		}
	}
	
	void HitPlayer () {
		if(playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage(attackDamage);
		}
	}

}
