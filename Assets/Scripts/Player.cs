﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed;
    public float rotX;
    public float rotY;
    public float rotZ;
    Rigidbody rb;

    public float timer = 2f;

    public float CuentaAtras = 1f;

    public bool isJump = false;

    public float jumpForce = 5.0f;

    private Camera mainCamera;
    
    public int Could = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.position += new Vector3(h, 0f, v);

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        jump();

    }

    void jump()
    {
        isJump = Input.GetMouseButtonDown(1);

        if (isJump && Could == 1)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

            Could += 1;

            CuentaAtras = 1;
        }

        if (Could > 1)
        {
            CuentaAtras += 1 * Time.deltaTime;
            
            if (CuentaAtras >= 2)
            {
                Could = 1;
            }
        }
    }
}
