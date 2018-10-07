using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode dive;
    public KeyCode fire;
    public float power;
    public float horizontalPower;
    public float diveRotation;
    public float fireSpeed;
    public GameObject impactEffect;
    public GameObject projectile;

    private bool allowFire = true;

    // Use this for initialization
    void Start()
    {

    }

    private IEnumerator Fire()
    {
        allowFire = false;
        Instantiate(projectile, transform.position, transform.rotation);
        yield return new WaitForSeconds(fireSpeed);
        allowFire = true;
    }

    //handle collision
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Instantiate(impactEffect, collision.contacts[0].point, new Quaternion());
        }
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

        //firing
        if (Input.GetKey(fire) && allowFire)
        {
            StartCoroutine(Fire());
        }
    }
}
