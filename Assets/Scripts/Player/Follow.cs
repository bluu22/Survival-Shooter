using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    public Transform follow;

    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - follow.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = follow.position + offset;
	}
}
