using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float moveSpeed = 17f;
    [SerializeField] float slowSpeed = 12f;
    [SerializeField] float boostSpeed = 22f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);

        if(Input.GetAxis("Vertical") != 0)
        {
            transform.Rotate(0, 0, -steerAmount);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }    
    }

}
