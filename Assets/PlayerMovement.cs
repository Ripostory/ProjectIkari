using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode dive;
    public float power;
    public float horizontalPower;
    public float diveRotation;
    public GameObject impactEffect;

    // Use this for initialization
    void Start()
    {

    }

    //handle collision
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(impactEffect, collision.contacts[0].point, new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        float rotationState = 0.0f;
        float direction = 0.0f;

        //handle saving rotational state
        if (Input.GetKeyDown(dive))
        {
            rotationState = body.rotation;
        }

        //get direction
        if (body.velocity.x > 0)
        {
            direction = -1.0f;
        }
        else
        {
            direction = 1.0f;
        }

        //dive
        if (!Input.GetKey(dive))
        {
            body.AddForce(new Vector2(0, power * Time.deltaTime));
        }
        else
        {
            body.angularVelocity = body.velocity.magnitude * diveRotation * direction;
        }

        //left right controls
        if (Input.GetKey(right))
        {
            body.AddForce(new Vector2(horizontalPower * Time.deltaTime, 0));
        }

        if (Input.GetKey(left))
        {
            body.AddForce(new Vector2(-horizontalPower * Time.deltaTime, 0));
        }
    }
}
