using UnityEngine;
using System.Collections;

public class HoleScript : MonoBehaviour {

    public Camera camera;

    float dmg = 9999f;
    float duration = 20f;
    float timer;
    float range;

    float timeOffset = 1f;
    //float deadGap = -1;
    //float deadStartGap = 0.5f;
    bool isActive = true;

    Color color;
    GameObject player;

    void Awake()
    {
        color = new Color(0, 0, 0, 255);
        range = transform.localScale.x * 10 / 4 * 8/10;
        timer = duration;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        //deadGap -= Time.deltaTime;

        if(timer + timeOffset > duration)
            GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.clear, color, timeOffset);
        
        if( timer + timeOffset < duration && timer - timeOffset > 0 && /*deadGap<0 &&*/ isActive)
        {
            //deadGap = deadStartGap;
            string[] tags = { "Player", "Enemy" };
            ExplosionScript.Explosion(transform.position, dmg, range,tags);
            if (player.GetComponent<PlayerHealth>().currentHealth < 0)
            {
                isActive = false;
                Rigidbody playerRigidBody = player.GetComponent<Rigidbody>();
                playerRigidBody.velocity = new Vector3(0, -3, 0);
                player.GetComponent<CapsuleCollider>().isTrigger = true;
                //camera.GetComponent<CameraFollow>().enabled = false;
            }
        }

        if(timer < timeOffset)
            GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.clear, Color.black, timeOffset);
        if (timer < 0)
            DestroyObject(gameObject);
    }
}
