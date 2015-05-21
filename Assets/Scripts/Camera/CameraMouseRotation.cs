using UnityEngine;
using System.Collections;

public class CameraMouseRotation : MonoBehaviour {

   // Vector3 oldMouse;
    //Vector3 newMouse;
    int sceneSphereMask;
    float range = Mathf.Infinity;

	void Start () {

        //oldMouse = Input.mousePosition;
        sceneSphereMask = LayerMask.GetMask("SceneSphere");
	}
	

	void FixedUpdate () {

        Ray sphereRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit sphereHit;

        if (Physics.Raycast(sphereRay, out sphereHit, range, sceneSphereMask))
        {
            Debug.Log("hitCollider");

            Vector3 direction = sphereHit.point - transform.position;

            Quaternion rotation = Quaternion.LookRotation(direction);

            this.transform.rotation = rotation;
        }
	}
}
