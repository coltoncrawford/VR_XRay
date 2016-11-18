using UnityEngine;
using System.Collections;

public class HighLightOnPoint : MonoBehaviour {

    //public Material onHighlight;
    //public Material onBase;
    public float angleThreshold;

    HiddenObjects[] objects;

	// Use this for initialization
	void Start () {
        objects = GameObject.FindObjectsOfType<HiddenObjects>();
        Debug.Log("Length: " + objects.Length);
	}
	
	// Update is called once per frame
	void Update () {
	    foreach(var obj in objects)
        {
            Vector3 temp = obj.transform.position - transform.position;
            temp.Normalize();
            if(Vector3.Dot(transform.forward,temp)> angleThreshold)
            {
                obj.ShowHiddenObjects();
                Debug.Log(obj.name + " In range" + obj.transform.position);
                Debug.DrawLine(obj.transform.position, transform.position);
            } else
            {
                obj.HideHiddenObjects();
            }
        }
	}
}
