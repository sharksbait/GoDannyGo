using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCTRL : MonoBehaviour
{
    public float moveSpeed = 9f;
    public Rigidbody2D rb; //the motor to our object
    Vector2 movement; //horizontal&vertical

    //health
    public static float health;
    
    private void Start()
    {
        health = 1;
        rb = GetComponent<Rigidbody2D>();
    }
    //collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HIT DETECTED!!!");
        health -= 0.2f;
    }

    void Update()
    {
        //controller
        movement.x = Input.GetAxisRaw("Horizontal"); //left&right pos, keys holding down
        movement.y = Input.GetAxisRaw("Vertical"); //up&down

        if (health <= 0)
        {
            Destroy(gameObject);
        }
            
    }

    private void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
