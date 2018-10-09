using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHP : MonoBehaviour {
    public int HP;
    public UnityEvent playerDead;

    bool playerDeadTriggered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //update realtime health
        TextMesh text = GetComponent<TextMesh>();
        text.text = HP.ToString();
	}

    public void Damage(int amount)
    {
        HP -= amount;
        if (HP < 0)
        {
            HP = 0;
        }

        if (HP == 0 && !playerDeadTriggered)
        {
            //signal when the player dies
            playerDead.Invoke();
            playerDeadTriggered = true;
        }
    }
}
