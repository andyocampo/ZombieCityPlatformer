using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    bool inside = false;
    float climbSpeed = 10;

    public LayerMask Climb;
    private CharacterController pc;
    private GameObject hitObject;

    void Start()
    {
        pc = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Climb")
        {
            inside = !inside;
        }
    }

    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "Climb")
        {
            inside = !inside;
        }
    }

    void FixedUpdate()
    {

        bool climb = Input.GetKey(KeyCode.Space);

        if (inside == true && climb)
        {
            Debug.Log("CLIMBING!!!");
            pc.Move(Vector3.up * climbSpeed * Time.smoothDeltaTime);
        }
    }

}