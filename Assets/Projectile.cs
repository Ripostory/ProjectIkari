using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float projectileSpeed = 1.0f;
    public int damage = 1;

	// Use this for initialization
	void Start () {
        //move in direction set
        gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.right * projectileSpeed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO check if hits a player
        if (collision.gameObject.tag == "Player")
        {

        }
        else if (collision.gameObject.tag == "Bullet")
        {
            //ignore
        }
        else
        {
            //kill object
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        //move in direction set
        //gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.forward * projectileSpeed;
    }
}
