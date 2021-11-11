using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movespeed;
    Transform leftPin, rightPin;
    Vector3 localScale;
    bool right = true;
    Rigidbody2D rb;
    //public GameObject platform1, platform2, platform3, platform4, ground1;

    private void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        leftPin = GameObject.Find("LeftPin1").GetComponent<Transform>();
        rightPin = GameObject.Find("RightPin1").GetComponent<Transform>();
    }

    private void Update()
    {
        if (transform.position.x > rightPin.position.x)
        {
            right = false;
        }
        if (transform.position.x < leftPin.position.x)
        {
            right = true;
        }
        if (right)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    void MoveRight()
    {
        right = true;
        localScale.x = 1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * movespeed, rb.velocity.y);
    }

    void MoveLeft()
    {
        right = false;
        localScale.x = -1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * movespeed, rb.velocity.y);
    }

}
