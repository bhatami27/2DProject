using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public Animator animator;
    public Transform groundCheck;
    public GameObject Light;
    public Text score;
    private int count;
    private int health;

    //public AudioSource pickUpSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        count = 14;
        SetCountText();
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));

        Vector2 move = new Vector2();
        move.x = Input.GetAxis("Horizontal")* speed;
        if (Input.GetButtonDown("Jump"))
        {
            move.y = 50 * jumpForce;
            if (Physics2D.OverlapCircle(groundCheck.position, .1f, 6))
            {
                print("grounded");
                move.y = 1 * jumpForce;
            }
        }
        rb.AddForce(move);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Light"))
        {
            collision.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count - 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText();
            //pickUpSound.Play();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            print("Hit");
            health -= 1;
            if (health == 0)
            {
                //SceneManager.LoadScene(1);
                score.text = ("You Lost!");
                SceneManager.LoadScene(3);
            }

        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            print("Hit");
            health -= 1;
            if (health == 0)
            {
                //SceneManager.LoadScene(1);
                score.text = ("You Lost!");
                SceneManager.LoadScene(3);
            }

        }
    }


    void SetCountText()
    {
        score.text = count.ToString();

        if (count <= 0)
        {
            // Set the text value of your 'winText'
            score.text = ("You Won!");
            SceneManager.LoadScene(2);

        }
    }
}
