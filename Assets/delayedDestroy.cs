using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayedDestroy : MonoBehaviour {
    public float additionalDelay = 0.0f;

	// Use this for initialization
	void Start () {
        if (GetComponent<Animator>() != null)
        {
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + additionalDelay);
        } else
        {
            Destroy(gameObject, additionalDelay);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
