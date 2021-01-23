using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI puntosText;
    public GameObject WinTextObject;
    private int vidas;
    public GameObject LoseTextObject;
    private Vector3 posicionInicio;
    private Vector4 posicionDerrota;
    private Vector3 posicionPodio;
    private float movementX;
    private float movementY;
    private int puntos;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        vidas = 3;

        SetConutText();

        WinTextObject.SetActive(false);

        LoseTextObject.SetActive(false);

        posicionInicio = transform.position;

        posicionDerrota = new Vector4(-2, -2, -2);

        posicionPodio = new Vector3(-5, 1, 20);
     
    }

    void OnMove(InputValue movementValue)
    {

        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

        //mensaje consola
        Debug.Log("Stoy en OnMove");

    }


    void SetConutText()
    {
        

        countText.text = "Cubos: " + count.ToString() + " Puntos: " + puntos.ToString() + " Vidas: " + vidas.ToString();
        
        if (count >= 25 && vidas >=0)
        {
            WinTextObject.SetActive(true);

            transform.position = posicionPodio;
        }
        else
        {

            if(vidas ==0 )
            {
                LoseTextObject.SetActive(true);

                transform.position = posicionDerrota;


            }

        }
    }


    void FixedUpdate()
    {
     
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);

            rb.AddForce(movement * speed);


  

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            puntos++;
            
            SetConutText();

        }
        if (other.gameObject.CompareTag("Enemy"))
        {

          

                transform.position = posicionInicio;
                puntos--;
                vidas--;
                SetConutText();

          
           

        }
    }
}