using UnityEngine;

public abstract class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;


    protected float timer;
    protected int shootableMask;
    AudioSource gunAudio;


    protected virtual void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunAudio = GetComponent<AudioSource> ();
    }


    protected virtual void Update()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
            gunAudio.Play();
            timer = 0f;
        }

    }




    protected virtual void Shoot ()
    {
        
    }


}
