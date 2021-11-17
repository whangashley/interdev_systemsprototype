using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreggBehavior : MonoBehaviour
{
    public float speed;

    private Transform target;
    public float pos;
    public bool pullBack;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;

        if (pullBack)           // automatically moving arm back
        {
            speed = 10;         // pull back fast
            newPos.x += speed * Time.deltaTime;
            transform.position = newPos;
        }
        else
        {
            speed = 3;

            newPos.y += speed * Time.deltaTime;

            transform.position = newPos;

            if(target.position.y - newPos.y >= 1 || target.position.y - newPos.y <= 1 || target.position.y == newPos.y)
            {
                speed = 10;     // stab fast
                newPos.x += speed * Time.deltaTime;
                transform.position = newPos;
            }
        }
        
        //movement();
    }
    /*
    void movement()
    {
        int randRange = Random.Range(1, 30);

        if (randRange == 1) //|| target.position.y > this.transform.position.y)
        {
            speed = 4;
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else if (randRange == 2) //|| target.position.y < this.transform.position.y)
        {
            speed = 4;
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
        else if(randRange == 3)
        {
            Stab();
        }
    }

    void Stab()
    {
        if(count == 0)
        {
            pos = transform.position.x;
        }
        count++;

        speed = 0;
        transform.position = new Vector2(transform.position.x + 10 * Time.deltaTime, transform.position.y);
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "gregg bounds")
        {
            transform.position = new Vector2(pos, transform.position.y);
            count = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 newPos = transform.position;

        // stop pulling back when bounds are hit
        if (collision.gameObject.tag == "bounds")
        {
            pullBack = false;
            speed = 0;

            newPos.x -= 2;
            transform.position = newPos;
        }

        if (collision.gameObject.tag == "hor bounds")
        {
            // bounces off the walls, changes direction
            speed *= -1;
        }


    }
}
