using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;
    public bool moveBack = false;
    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;        // player position

        if (moveBack)           // automatically moving arm back
        {
            speed = 10;         // pull back fast
            newPos.x += speed * Time.deltaTime;
            transform.position = newPos;
        }
        else
        {
            speed = 0;

            UpDown();           // general controls
        
            if (Input.GetKey(KeyCode.C))            // to stab
            {
                speed = 10;     // stab fast
                newPos.x -= speed * Time.deltaTime;
                transform.position = newPos;
            }
        }
    }

    void UpDown()
    {
        speed = 3;

        Vector3 newPos = transform.position;    // sets the vector position of the gameobject to newPos
        if (Input.GetKey(KeyCode.UpArrow))      // when you press up key
        {
            newPos.y += speed * Time.deltaTime; // y pos increases positively
        }
        else if (Input.GetKey(KeyCode.DownArrow))      // when you press down key
        {
            newPos.y -= speed * Time.deltaTime; // y pos decreases negatively
        }
        transform.position = newPos;            // set the vector pos to newPos at after keys are pressed
    }

    // collision for bound walls
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 newPos = transform.position;

        // stop pulling back when bounds are hit
        if (collision.gameObject.tag == "bounds")
        {
            moveBack = false;
            speed = 0;

            newPos.x -= 2;
            transform.position = newPos;
        }
    }

    // trigger collider for bounds to stab
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "mae bounds")
        {
            moveBack = true;
        }
    }
}
