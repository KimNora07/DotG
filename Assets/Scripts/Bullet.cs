using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * moveSpeed;

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(PlayerController.instance != null)
            {
                PlayerController.instance.Die();
            }
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
