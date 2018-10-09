using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //hide
        MeshRenderer render = GetComponent<MeshRenderer>();
        Collider2D collider = GetComponent<Collider2D>();
        render.enabled = false;
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowButton()
    {
        //hide
        MeshRenderer render = GetComponent<MeshRenderer>();
        Collider2D collider = GetComponent<Collider2D>();
        render.enabled = true;
        collider.enabled = true;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
