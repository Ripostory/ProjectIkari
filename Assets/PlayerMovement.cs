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
    public int ProjectileLayer;
    public GameObject impactEffect;
    public GameObject projectile;
    public GameObject healthBar;

    private bool allowFire = true;
    private bool isDead = false;

    // Use this for initialization
    void Start()
    {

    }

    private IEnumerator Fire()
    {
        allowFire = false;
        GameObject childProjectile = Instantiate(projectile, transform.position, transform.rotation);
        childProjectile.layer = ProjectileLayer;
        yield return new WaitForSeconds(fireSpeed);
        allowFire = true;
    }

    //handle collision
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //get healthbar in case event is a damaging collision
        PlayerHP hpScript = healthBar.GetComponent<PlayerHP>();

        if (collision.gameObject.tag == "Wall")
        {
            Instantiate(impactEffect, collision.contacts[0].point, new Quaternion());
            hpScript.Damage(1);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //get healthbar in case event is a damaging collision
        PlayerHP hpScript = healthBar.GetComponent<PlayerHP>();

        if (collision.gameObject.tag == "Bullet")
        {
            //handle bullet collision
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            hpScript.Damage(projectile.damage);
        }
    }

    public void KillPlayer()
    {
        isDead = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
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
}
