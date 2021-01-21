using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{


    private NavMeshAgent pathfinger;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        pathfinger = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        pathfinger.SetDestination(target.position);
    }
}
