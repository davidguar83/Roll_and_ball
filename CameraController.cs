using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;


    
    //Se llama al inicio antes de la primera actualización del cuadro
    void Start()
    {

        offset = transform.position - player.transform.position;


    }

    
    //La actualización se llama una vez por cuadro
    void LateUpdate()
    {

        transform.position = player.transform.position + offset;

    }
}
