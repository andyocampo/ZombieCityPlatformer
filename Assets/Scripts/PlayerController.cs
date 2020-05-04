using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;

    public float GroundDistance = 0.5f;
    public float movespeed;
    public float jumpSpeed;
    public float gravity = -9.81f;
    bool isGrounded;

    public Vector3 velocity;
    private Vector3 move;
    public LayerMask Ground;
    private Transform groundChecker;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        groundChecker = transform.GetChild(0);
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        move = transform.right * hInput + transform.forward * vInput;

        velocity.y += gravity * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        bool jump;
        bool run;
        bool crouch;

        jump = Input.GetButton("Jump");
        run = Input.GetKey(KeyCode.LeftShift);
        crouch = Input.GetKey(KeyCode.LeftControl);

        cc.Move(velocity * Time.deltaTime);

        if (isGrounded)
        {
          //Debug.Log("is grounded");
            Move();

            if (jump)
            {
                velocity.y = Mathf.Sqrt(jumpSpeed  * gravity);
            }
            if (run)
            {
                movespeed = 20f;
            }
            else if (crouch)
            {
                transform.localScale = new Vector3(1, 0.5f, 1);
                movespeed = 5;
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                movespeed = 10f;
            }
        }
        else
        {
            //Debug.Log("is not grounded");
            AirMove();
        }
    }

    private void Move()
    {
        //Debug.Log(rb.position);
        cc.Move(move * movespeed * Time.deltaTime);
    }
    private void AirMove()
    {
        cc.Move(move * movespeed/1.5f * Time.deltaTime);
    }
}