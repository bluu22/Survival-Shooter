using UnityEngine;
using System.Collections;

public class TNTScript : MonoBehaviour {

    public float dmg = 100f;
    public float explosionTime = 5f;
    public GameObject area;

    float timer=0f;
    public float range;
    float planeScale = 10f;

    TextMesh text;


	void Awake () {
        text = GetComponentInChildren<TextMesh>();
        timer = explosionTime;
        range = area.transform.localScale.x * planeScale/ 4;
	}
	

	void Update () {
        timer -= Time.deltaTime;
        text.text = ((int)timer).ToString();

        if (timer <= 0)
        {
            ExplosionScript.Explosion(transform.position, dmg, range, "Explosion", "Enemy");
            DestroyObject(gameObject);
        }

	}



}
