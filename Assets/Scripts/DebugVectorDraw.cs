using UnityEngine;
using System.Collections;

public class DebugVectorDraw : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(transform.position, transform.position + (transform.forward * 100),Color.red);
	}
}
