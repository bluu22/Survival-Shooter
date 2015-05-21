using UnityEngine;
using System.Collections;

public class TNTBoxScript : CubeManager {

	protected override void Bonus(Collider col)
    {
        col.GetComponent<PlayerActions>().bombQty += ammount;
    }
}
