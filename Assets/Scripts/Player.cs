using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rb;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = Vector3.up * 4;
        }

        if (transform.position.y >= 3.5)
        {
            rb.velocity = Vector3.down * 2;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "avoid")
        {
            GameManager.thisManager.GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "score")
        {
            GameManager.thisManager.UpdateScore(1);
        }
    }
}
