using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 100;

    public Animator anim;
    public HiddenObjects obs;

    private bool isDead = false;

	// Use this for initialization
	void Start () {
        
    }
	
    public void Damage(float a)
    {
        if (isDead) return;
        health -= a;
        if(health < 0)
        {
            isDead = true;
            if(anim != null)
            {
                anim.SetBool("isDead", true);
            }
            if(obs != null)
            {
                obs.HideHiddenObjects();
            }
            //Destroy(gameObject);
        }
    }
}
