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
        Vector3 newPos = transform.position;

        if (moveBack)
        {
            do
            {
                newPos.x += speed * Time.deltaTime;
                transform.position = newPos;
            } while (moveBack);
        }

        UpDown();
        
        if (Input.GetKey(KeyCode.C))
        {
            newPos.x -= speed * Time.deltaTime;
            transform.position = newPos;
        }

    }

    void UpDown()
    {
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Vector3 newPos = transform.position;

        if (other.gameObject.tag == "mae bounds")
        {
            moveBack = true;
        }

        if(other.gameObject.tag == "bounds")
        {
            moveBack = false;
        }
    }
}
