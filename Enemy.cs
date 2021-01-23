using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{


    private NavMeshAgent pathfinger;
    private Transform target;

   
    void Start()
    {
        pathfinger = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
    }

   
    void Update()
    {
        pathfinger.SetDestination(target.position);
    }
}
