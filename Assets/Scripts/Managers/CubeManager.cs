using UnityEngine;
using System.Collections;

public abstract class CubeManager : MonoBehaviour {
    // zmienic na abstract

    AudioSource audio;
    Animator anim;

    public int ammount;

	void Awake () {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
	}
	
	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Bonus(other);
            audio.Play();
            anim.SetTrigger("destroy");
        }
    }
	

    protected virtual void Bonus(Collider other)
    {
        
        
    }


    void Destroy()
    {
        DestroyObject(transform.parent.gameObject);
    }
    

}
