using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float moveSpeed = 17f;
    [SerializeField] float slowSpeed = 12f;
    [SerializeField] float boostSpeed = 22f;

    void Start()
    {
        int levDiff = PlayerPrefs.GetInt("LevelOfDifficulty", 0);
        if(levDiff == 0)
        {
            steerSpeed -= 20f;
            moveSpeed -= 2f;
            slowSpeed -= 2f;
            boostSpeed -= 5f;
        }
        else if(levDiff == 2)
        {
            steerSpeed += 20f;
            moveSpeed += 2f;
            slowSpeed += 2f;
            boostSpeed += 5f;
        }
    }

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
