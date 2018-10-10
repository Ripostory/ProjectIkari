using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour {
    public float scrollX = 0.5f;
    public float scrollY = 0.5f;

    float internalScrollX = 0.0f;
    float internalScrollY = 0.0f;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        internalScrollX += Time.deltaTime * scrollX;
        internalScrollY += Time.deltaTime * scrollY;
        //keep scroll value bounded
        internalScrollX %= 10;
        internalScrollY %= 10;

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(internalScrollX, internalScrollY);
    }
}
