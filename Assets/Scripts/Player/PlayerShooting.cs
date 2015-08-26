using UnityEngine;
using Fungus;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
	public Flowchart flowChart;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    float effectsDisplayTime = 0.2f;
	Animator anim;

	private bool isChart = false;

    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
		anim = GetComponentInParent<Animator> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if (flowChart != null && flowChart.GetVariable<BooleanVariable> ("charting") != null) {
			isChart = flowChart.GetVariable<BooleanVariable> ("charting").value;
		}

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && !isChart)
        {
            Shoot ();
        }

		if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
		anim.SetBool ("IsAttacking", false);
    }


    void Shoot ()
    {
        timer = 0f;

        //gunAudio.Play ();

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

		anim.SetBool ("IsWalking", false);
		anim.SetBool ("IsAttacking", true);

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }
}
