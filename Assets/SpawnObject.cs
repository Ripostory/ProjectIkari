using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
    public GameObject spawnableObject;
    public Vector3 initialVelocity;
    public float initialScale;
    public float intialRotationalVelocity;
    public float spawnRate;
    public float randomRotationalDeviation;
    public float randomScaleDeviation;
    public float randomDeviation;

    private bool ableToSpawn = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(AttemptSpawn());
	}

    private IEnumerator AttemptSpawn()
    {
        if (ableToSpawn)
        {
            Spawn();
            ableToSpawn = false;

            //wait given amount before spawning again
            float waitTime = spawnRate + (Random.value * randomDeviation);
            yield return new WaitForSeconds(waitTime);
            ableToSpawn = true;
        }
    }

    private void Spawn()
    {
        //set initial scale
        float scale = initialScale + (Random.value * randomScaleDeviation);

        //spawns a new object
        GameObject childObj = Instantiate(spawnableObject, transform);
        childObj.transform.localScale = new Vector3(scale, scale, scale);

        //set variables
        Rigidbody2D childBody = childObj.GetComponent<Rigidbody2D>();
        childBody.velocity = initialVelocity;
        float angularVelocity = intialRotationalVelocity + (Random.value * randomRotationalDeviation);
        childBody.angularVelocity = angularVelocity;
        childObj = null;
    }
}
