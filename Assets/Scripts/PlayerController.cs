using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Rigidbody rb;
    public float moveSpeed = 8f;

    private void Awake()
    {
        instance = this;
    }

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

        float xMoveSpeed = xInput * moveSpeed;
        float zMoveSpeed = zInput * moveSpeed;

        Vector3 newVelocity = new Vector3(xMoveSpeed, 0f, zMoveSpeed);

        rb.velocity = newVelocity;
    }

    public void Live()
    {
        gameObject.SetActive(false);

        GameManager.Instance.isGameWin = true;
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager.Instance.isGameOver = true;
    }
}
