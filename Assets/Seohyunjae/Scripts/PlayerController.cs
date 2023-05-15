using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// »ó¼Ó(Inheritance)
public class PlayerController : MonoBehaviour
{
    public delegate void MLBDelegate();
    public delegate void MRBDelegate();
    private MLBDelegate mlbCallback = null;
    private MRBDelegate mrbCallback = null;

    public delegate void VoidVoidDelegate();
    public delegate void VoidIntDelegate(int _val);
    private VoidVoidDelegate useCallback = null;

    // Class Member Variables
    private Transform tr = null;
    private Rigidbody rb = null;

    // Attribute
    [SerializeField][Range(10f, 50f)]
    private float moveSpeed = 10f;
    [SerializeField, Range(50f, 100f)]
    private float rotSpeed = 50f;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        //tr = transform;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //tr.position.z = 10f;
            //Vector3 newPos = transform.position;
            //newPos.z += moveSpeed * Time.deltaTime;
            //transform.position = newPos;
            rb.velocity = tr.forward * moveSpeed;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 newPos =
                transform.position +
                (-tr.forward * moveSpeed * Time.deltaTime);
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

        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 newRot = tr.rotation.eulerAngles;
            newRot.y -= rotSpeed * Time.deltaTime;
            tr.rotation = Quaternion.Euler(newRot);
            //tr.rotation.eulerAngles = newRot;

            //r.localRotation
        }

        if (Input.GetKey(KeyCode.E))
        {
            // Function Overloading
            tr.Rotate(Vector3.up,
                      rotSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            tr.localScale = Vector3.one * 2f;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            tr.localScale = Vector3.one;
        }


        // Mouse Input
        if (Input.GetMouseButtonDown(0))
        {
            if (mlbCallback != null)
                mlbCallback();
        }

        if (Input.GetMouseButtonDown(1))
        {
            mrbCallback?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            useCallback?.Invoke();
        }
    }

    //private void OnCollisionEnter(Collision _collision)
    //{
    //    Debug.Log(_collision.gameObject.name);
    //}

    public void SetMLBDelegate(
        MLBDelegate _callback)
    {
        mlbCallback = _callback;
    }

    public void SetMRBDelegate(
        MRBDelegate _callback)
    {
        mrbCallback = _callback;
    }

    public void SetUseDelegate(
        VoidVoidDelegate _callback)
    {
        useCallback = _callback;
    }
}
