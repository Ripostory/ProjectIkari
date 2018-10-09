using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeshButton : MonoBehaviour {
    public Font defaultFont;
    public Color hoverColor;
    public Color defaultColor;
    public Color mouseDownColor;
    public UnityEvent click;

	// Use this for initialization
	void Start () {
        TextMesh text = GetComponent<TextMesh>();
        text.color = defaultColor;
        text.font = defaultFont;
    }

    public void OnMouseEnter()
    {
        GetComponent<TextMesh>().color = hoverColor;
    }

    public void OnMouseExit()
    {
        GetComponent<TextMesh>().color = defaultColor;
    }

    public void OnMouseDown()
    {
        GetComponent<TextMesh>().color = mouseDownColor;
        click.Invoke();
        Destroy(gameObject);
    }

    public void OnMouseUp()
    {
        GetComponent<TextMesh>().color = defaultColor;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
