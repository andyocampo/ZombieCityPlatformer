using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] GameObject Player;

    void Start()
    {
        transform.GetComponent<Transform>();
    }

    void Update()
    {
        transform.Translate(transform.position - Player.transform.position);
    }
}
