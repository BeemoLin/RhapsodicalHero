using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
	Animator anim;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;

    void Awake ()
    {
		anim = GetComponentInParent<Animator>();
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
    }


    void Update ()
    {
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination (player.position);

			if (nav.velocity.x == 0 && nav.velocity.z == 0) {
				anim.SetBool ("IsRun", false);
			} else {
				anim.SetBool ("IsRun", true);
			}
        } else {
			anim.SetBool ("IsRun", false);
            nav.enabled = false;
        }


    }
}
