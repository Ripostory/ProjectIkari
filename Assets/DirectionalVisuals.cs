using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalVisuals : MonoBehaviour {
    public KeyCode dive;
    public Sprite diveSprite, downSprite, upSprite, rightSprite, leftSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        //flip on movement direction
        if (body.angularVelocity < 0)
        {
            //sprite.flipY = false;
        }
        else
        {
            //sprite.flipY = true;
        }

        //choose sprite based on angular direction
        float angle = Vector3.SignedAngle(new Vector3(1, 0, 0), transform.up, new Vector3(0, 0, 1));
        if (angle > -45.0f && angle <= 45.0f)
        {
            sprite.sprite = rightSprite;
        } else if(angle > 45.0f && angle <= 135.0f)
        {
            sprite.sprite = downSprite;
        } else if ((angle > 135.0f && angle <= 180.0f) || (angle > -180.0f && angle <= -135.0f))
        {
            sprite.sprite = leftSprite;
        } else
        {
            sprite.sprite = upSprite;
        }

        //if (Input.GetKey(dive))
        //{
        //    sprite.sprite = diveSprite;
        //}
    }
}
