using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 8f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            rb.AddForce(0f, 0f, moveSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            rb.AddForce(0f, 0f, -moveSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            rb.AddForce(-moveSpeed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            rb.AddForce(moveSpeed, 0f, 0f);
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
