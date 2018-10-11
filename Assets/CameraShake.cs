using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LowShake()
    {
        Sequence shakeSeq = DOTween.Sequence();
        shakeSeq.Append(transform.DOShakePosition(0.5f, 0.1f));
        shakeSeq.Append(transform.DOMove(new Vector3(0, 0, transform.position.z), 0.01f));
    }

    public void MediumShake()
    {

    }

    public void HighShake()
    {

    }
}
