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
    bool crouched;

    public Vector3 velocity;
    private Vector3 move;
    public LayerMask Ground;
    private Transform groundChecker;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        groundChecker = transform.GetChild(0);
        crouched = false;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);


        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        move = transform.right * hInput + transform.forward * vInput;

        velocity.y += gravity * Time.deltaTime;
        Crouch();
    }

    private void FixedUpdate()
    {
        bool jump;
        bool run;

        jump = Input.GetKey(KeyCode.Space);
        run = Input.GetKey(KeyCode.LeftShift);

        cc.Move(velocity * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        if (isGrounded)
        {
          //Debug.Log("is grounded");
            Move();

            if (jump)
            {
                velocity.y = Mathf.Sqrt(jumpSpeed * -2 * gravity);
            }
            if (run)
            {
                movespeed = 16f;
            }
            else
            {
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

    private void Crouch()
    {
        //Debug.Log($"crouched: {crouched}");
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouched = !crouched;
        }
        if (crouched)
        {
            transform.localScale = new Vector3(1, 0.4f, 1);
            movespeed = 5;
        }
        else if(!crouched)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}