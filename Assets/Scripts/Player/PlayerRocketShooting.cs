using UnityEngine;
using System.Collections;

public class PlayerRocketShooting : PlayerShooting  {

    public float shellSpeed = 20f;
    public float shellExplosionRange = 1.5f;

    protected override void Shoot()
    {

        GameObject shell = (GameObject)Instantiate(Resources.Load("RocketShell"));
        shell.transform.position = transform.position;
        shell.transform.rotation = transform.rotation;
        shell.GetComponent<Rigidbody>().velocity = transform.forward * shellSpeed;

        RocketShell shellScript = shell.GetComponent<RocketShell>();
        shellScript.dmg = damagePerShot;
        shellScript.range = shellExplosionRange;
    }

}
