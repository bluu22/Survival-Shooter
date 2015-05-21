using UnityEngine;
using System.Collections;

public class RocketShell : MonoBehaviour {

    public int dmg;
    public float range;

    int shootableMask;

	void Awake () {
        shootableMask = (int)Mathf.Log( LayerMask.GetMask("Shootable"),2);
	}
	
	void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.layer == shootableMask)
        {
            ExplosionScript.Explosion(transform.position, transform.rotation, dmg, range, "RocketExplosion", "Enemy");
            DestroyObject(gameObject);
        }


    }





}
