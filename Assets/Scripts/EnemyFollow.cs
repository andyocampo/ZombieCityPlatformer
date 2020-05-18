using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nav;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponentInParent<NavMeshAgent>();
        nav.speed = Random.Range(9, 13);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            nav.destination = player.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            nav.destination = player.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            nav.destination = transform.position;
        }
    }

}
