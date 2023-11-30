using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f, moveSpeed = 0.01f;


    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        while (moveSpeed > 10f)
        {
            moveSpeed -= 2f;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost" && moveSpeed < 25f)
        {
            moveSpeed += 2f ;
        }

    }
}
