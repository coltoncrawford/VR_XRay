﻿using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

    public float dmg = 10;

	// Use this for initialization
	void Start () {
	
	}
    
    void OnTriggerEnter(Collider c)
    {
        Health h = c.gameObject.GetComponent<Health>();
        if(h != null)
        {
            h.Damage(dmg);
        }
        Destroy(gameObject);
    }
}
