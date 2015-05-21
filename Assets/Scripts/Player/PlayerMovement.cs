using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidBody;
    Collider collider;
    int FloorMask;
    float camReyLength= 100f;
    bool canJump = false;

    void Awake()
    {
        FloorMask = LayerMask.GetMask("Floor");
        playerRigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float jump = Input.GetAxisRaw("Jump");

        Move(h,v);
        Jump(jump);
        Turning();

        Animating(h, v);
    }

    #region alternate jump
    //void OnCollisionEnter()
    //{
    //    canJump = true;
    //}

    //void OnCollisionExit()
    //{
    //    canJump = false;
    //}

    //void Jump(float jump)
    //{
    //    if(canJump && jump==1)
    //    {
    //        canJump = false;
    //        playerRigidBody.AddForce(new Vector3(0, 250f, 0));
    //    }
    //}

    #endregion

    void Jump(float jump)
    {
        RaycastHit rayHit;
        //

        double distance = Mathf.Infinity;
        Vector3 bounds = GetComponent<Collider>().bounds.size;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                Vector3 offset = Vector3.Normalize(new Vector3(i, 0, j));
                Vector3 origin = transform.position;
                origin.x += bounds.x / 4 * offset.x;
                origin.z += bounds.z / 4 * offset.z;
                Physics.Raycast(origin, -transform.up, out rayHit, 100);
                distance = distance < rayHit.distance ? distance : rayHit.distance;
                Debug.DrawRay(origin, -transform.up * 5, Color.red);
                //Debug.Log("Distance [" + i + "] [" + j + "] :" + rayHit.distance);
            }
        }
        //Debug.Log("Min distance: " + distance);

        if (jump == 1 && distance < 0.05)
        {
            playerRigidBody.AddForce(new Vector3(0, 250f, 0));
        }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidBody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camReyLength, FloorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0;

            Quaternion rotation = Quaternion.LookRotation(playerToMouse);

            playerRigidBody.MoveRotation(rotation);
        }


        
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0 || v != 0;
        anim.SetBool("isMoving", walking);   
    }


}
