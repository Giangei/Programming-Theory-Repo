using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200;
    [SerializeField] float moveSpeed =10;
    [SerializeField] float slowSpeed = 7;
    [SerializeField] float boostSpeed = 15;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical")* moveSpeed* Time.deltaTime; 
        float stearAmount = Input.GetAxis("Horizontal")*steerSpeed *Time.deltaTime;
        transform.Rotate(0, 0, -stearAmount);
        transform.Translate(0,moveAmount,0 , Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boost"))
        {
            moveSpeed = boostSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }
}