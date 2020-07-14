﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArañaE : MonoBehaviour
{
    public int vida = 10;
    public float velo = 10f;
    public int ataq = 2;

    public float VisionRad;

    public GameObject player;

    Vector3 initialPosition;

    public float dist;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (vida <= 0)
        {
            Destroy(gameObject);
        }

        Vector3 target = initialPosition;

        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < VisionRad) target = player.transform.position;

        float fixedSpeed = velo * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.red);   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, VisionRad);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            vida = vida - 1;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Health>().RestarVida(ataq);
        }

        if (collision.gameObject.CompareTag("Araña"))
        {

        }
    }
}
