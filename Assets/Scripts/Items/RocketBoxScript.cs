using UnityEngine;
using System.Collections;

public class RocketBoxScript : CubeManager {

    public float duration;

    protected override void Bonus(Collider col)
    {

        col.GetComponent<PlayerActions>().GunBonus(PlayerActions.GunMode.Rocket, duration);
    }
}
