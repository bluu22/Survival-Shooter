using UnityEngine;
using System.Collections;

public class HealthBoxScript : CubeManager {

    protected override void Bonus(Collider other)
    {
        other.gameObject.GetComponent<PlayerHealth>().Heal(ammount);
    }
	
}
