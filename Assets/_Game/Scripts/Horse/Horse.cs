using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed * Vector3.forward.z);
    }
}
