using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour 
{
    [SerializeField]float rcsThrust = 100f;
    [SerializeField] float MThrust = 100f;

    Rigidbody rigidBody;
    AudioSource audioSource;
	// Use this for initialization
	void Start () 
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        Rotate();
        Thrusting();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Dead");
                break;
            case "Fuel":
                print("fuel");
                break;
            default:
                print("Dead");
                break;
        }
    }

    private void Thrusting()
    {
        float speedThisFrame = MThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidBody.AddRelativeForce(Vector3.up * speedThisFrame);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
    private void Rotate()
    {
        rigidBody.freezeRotation = true;

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            
            transform.Rotate(-Vector3.forward * rotationThisFrame);

            rigidBody.freezeRotation = false;
        }
    }

  
}
