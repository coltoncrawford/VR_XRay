using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
    public void Damage(float a)
    {
        health -= a;
        if(health < 0)
        {
            Destroy(gameObject);
        }
    }
}
