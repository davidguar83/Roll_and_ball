using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{


    private NavMeshAgent pathfinger;
    private Transform target;
    private Vector3 posicionInicio;

   
    void Start()
    {
        pathfinger = GetComponent<NavMeshAgent>();

        posicionInicio = transform.position;

        target = GameObject.Find("Player").transform;
    }

   
    void Update()
    {
        pathfinger.SetDestination(target.position);

        Debug.Log(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            transform.position = posicionInicio;

        }
    }


}
