using UnityEngine;
using System.Collections;

public class PlayerMovementFPS : MonoBehaviour {

    public Camera camera;
    public float speed = 6f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
	}

    void Move(float h, float v)
    {
        Vector3 movement =  camera.transform.forward*v + camera.transform.right*h ;
        movement.y = 0;

        //Debug.Log(movement );

        transform.Translate(movement * speed * Time.deltaTime);
    }
}
