using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ExplosionScript : MonoBehaviour {

   

    public static GameObject Explosion(Vector3 position, float dmg, float range,string animString, params string[] tagList)
    {
        Explosion(position, dmg, range, tagList);

        GameObject explosion = (GameObject)Instantiate(Resources.Load(animString));
        explosion.transform.position = position;

        return explosion;
    }

    public static void Explosion(Vector3 position, Quaternion rotation, float dmg, float range, string animString, params string[] tagList)
    {
        GameObject explosion = Explosion(position, dmg, range, animString, tagList);
        explosion.transform.rotation = rotation;
    }

    public static void Explosion(Vector3 position, float dmg, float range, params string[] tagList)
    {
        List<GameObject> enemyList = new List<GameObject>();

        foreach (string tag in tagList)
        {
            enemyList.AddRange(GameObject.FindGameObjectsWithTag(tag));
        }

        foreach (GameObject enemy in enemyList)
        {
            Vector3 hitPoint = enemy.GetComponent<Collider>().ClosestPointOnBounds(position);
            float distance = Vector3.Distance(hitPoint, position);

            int outDmg = (int)dmg;

            if (distance <= range)
            {
                EnemyHealth enemyHealth;
                PlayerHealth playerHealth;

                if(enemyHealth = enemy.GetComponent<EnemyHealth>())
                    enemyHealth.TakeDamage(outDmg, hitPoint);

                if (playerHealth = enemy.GetComponent<PlayerHealth>())
                    playerHealth.TakeDamage(outDmg);
            }
        }
    }
	
}
