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
    public GameObject WinTextObject;
  

    private float movementX;
    private float movementY;
   

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetConutText();

        WinTextObject.SetActive(false);
     
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

        countText.text = "Count: " + count.ToString();
        if (count >= 25)
        {
            WinTextObject.SetActive(true);
          
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
            SetConutText();

        }
        /* if (other.gameObject.CompareTag("Enemy")) { 
       
           // this.transform.position = startPos;
           
            if (count > 0)
            {
                count = count - 1;
                SetConutText();

            }

        
        }

         if (other.gameObject.CompareTag("Enemy"))
        {

            other.gameObject.transform.position = new Vector4(0, 5, 4);

        }

        */

    }
}