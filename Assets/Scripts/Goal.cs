using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{ 

    void Update()
    {
        float speed = 40;
        float rotateSpeed = speed * Time.deltaTime;

        transform.Rotate(0, 0, rotateSpeed, Space.Self);
    }
}
