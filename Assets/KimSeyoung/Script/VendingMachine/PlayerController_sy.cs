using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_sy : MonoBehaviour
{
    private Transform tr = null;
    private Rigidbody rb = null;

    [SerializeField][Range(10f, 50f)] private float moveSpeed = 10f;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        { rb.velocity = tr.forward * moveSpeed; }

        if (Input.GetKeyUp(KeyCode.W)) { rb.velocity = Vector3.zero; }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 newPos = transform.position + (-tr.forward * moveSpeed * Time.deltaTime);
            transform.position = newPos;
        }

        if (Input.GetKey(KeyCode.A))
        {
            tr.Translate(
                Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            tr.Translate(
                Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}
