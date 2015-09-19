﻿using UnityEngine;
using UnityEngine.UI;
using SnazzlebotTools.ENPCHealthBars;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
	
    Animator anim;
    AudioSource enemyAudio;
    //ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
	ENPCHealthBar npcHealth;
    bool isDead;
    bool isSinking;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        //hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
		npcHealth = GetComponent<ENPCHealthBar> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;

		npcHealth.Value = currentHealth;

        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();
		if(currentHealth > 0) {
			anim.SetTrigger ("IsHit");
		}

        if(currentHealth <= 0)
        {
			Debug.Log (currentHealth);
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        //capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();

		StartSinking ();
    }


    public void StartSinking ()
    {
        GetComponent <NavMeshAgent> ().enabled = false;
        //GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
