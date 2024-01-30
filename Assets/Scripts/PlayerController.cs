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
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        float xMoveSpeed = xInput * moveSpeed * Time.deltaTime;
        float zMoveSpeed = zInput * moveSpeed * Time.deltaTime;

        Vector3 newVelocity = new Vector3(xMoveSpeed, 0f, zMoveSpeed);

        rb.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
