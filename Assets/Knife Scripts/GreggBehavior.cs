using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreggBehavior : MonoBehaviour
{
    public float speed;

    private Transform target;
    public float pos;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (target.position.y + 1 >= this.transform.position.y || target.position.y - 1 <= this.transform.position.y)
        {
            //Stab();
        }*/

        movement();
    }

    void movement()
    {
        int randRange = Random.Range(1, 30);

        if (randRange == 1) //|| target.position.y > this.transform.position.y)
        {
            speed = 3;
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else if (randRange == 2) //|| target.position.y < this.transform.position.y)
        {
            speed = 3;
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
        else if(randRange == 3)
        {
            //Stab();
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "gregg bounds")
        {
            transform.position = new Vector2(pos, transform.position.y);
            count = 0;
        }
    }
}
