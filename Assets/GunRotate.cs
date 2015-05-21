using UnityEngine;
using System.Collections;

public class GunRotate : MonoBehaviour {

    public Camera camera;

    Vector3 rotationOffset;


	// Use this for initialization
	void Start () {

        rotationOffset = transform.rotation.eulerAngles - camera.transform.rotation.eulerAngles;

	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(camera.transform.rotation.eulerAngles + rotationOffset);
	}
}
