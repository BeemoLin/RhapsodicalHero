using UnityEngine;
using System.Collections;

public class PlayHit : MonoBehaviour
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

		if (anim.GetInteger ("ActionID") != 0) {
			spearCollider.enabled = true;
		} else {
			spearCollider.enabled = false;
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
		HitPlayer (other);
	}
	
	void HitPlayer (Collider other) {

		EnemyHealth enemyHealth = other.GetComponent <EnemyHealth> ();
		if(enemyHealth != null)
		{
			enemyHealth.TakeDamage (attackDamage);
		}
	}

}
