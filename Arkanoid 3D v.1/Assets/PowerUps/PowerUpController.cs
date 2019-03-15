using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour 
{
    private Rigidbody rb;

    public float fallSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        rb.velocity = new Vector3(0.0f, -fallSpeed, 0.0f);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Paddle") {
            other.gameObject.SendMessage("MessagedSizeUp");

            Destroy(gameObject);
        }
    }
}
