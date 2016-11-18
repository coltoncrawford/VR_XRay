using UnityEngine;
using System.Collections;

public class HighLightOnPoint : MonoBehaviour {

    public Material onHighlight;
    public Material onBase;
    public float angleThreshold;

    GameObject[] people;

	// Use this for initialization
	void Start () {
        people = GameObject.FindGameObjectsWithTag("person");
	}
	
	// Update is called once per frame
	void Update () {
	    foreach(var person in people)
        {
            Vector3 temp = person.transform.position - transform.position;
            temp.Normalize();
            if(Vector3.Dot(transform.forward,temp)> angleThreshold)
            {
                person.GetComponent<Renderer>().material = onHighlight;
            } else
            {
                person.GetComponent<Renderer>().material = onBase;
            }
        }
	}
}
