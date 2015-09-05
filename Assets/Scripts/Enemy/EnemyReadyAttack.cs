using UnityEngine;
using System.Collections;

public class EnemyReadyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
			Attack ();
        }

		if(timer > 0.75f) {
			anim.SetBool("IsAttack", false);
		}

        if(playerHealth.currentHealth <= 0)
        {
			// EnemyIdle
            anim.SetTrigger("PlayerDead");
        }
    }

    void Attack ()
    {
        timer = 0f;

		if (playerHealth.currentHealth > 0) {
			anim.SetBool ("IsAttack", true);
		}
    }
}
