﻿using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {


    public float movementSpeed = 1.0f;
    public float rorateSpeed = 3.0f;
    public Rigidbody abc;
    private bool run;
    public Animator ab;
    public bool jump;
    // Use this for initialization
    void Start () {
        run = false;
        ab = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.LeftShift))
            run = true;
        else
            run = false;
        if (Input.GetKey(KeyCode.W))
        {


            if (run)
            {
                transform.position += transform.forward * Time.deltaTime * movementSpeed ;
                
                ab.Play("RUN00_F");
            }
            else
            {
                transform.position += transform.forward * Time.deltaTime * movementSpeed * 0.5f;
            
                ab.Play("WALK00_F");
            }

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
            ab.Play("WALK00_B");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rorateSpeed * Time.deltaTime * 2);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rorateSpeed * Time.deltaTime * 2);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            abc.AddForce(0, 300, 0);
            ab.SetBool("jump", true);
        }
        else {
            ab.SetBool("jump", false);
        }

    }
}
