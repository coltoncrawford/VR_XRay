using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {

    public Transform[] objects;

    public float radius = 1;
    public int min = 1;
    public int max = 2;

	// Use this for initialization
	void Awake () {
        int num = Random.Range(min, max);
        for(int n = 0; n < num; ++n)
        {
            Transform newT = Instantiate(objects[Random.Range(0, objects.Length)]);
            newT.SetParent(transform, false);
            newT.localPosition = Random.insideUnitSphere * radius;
            newT.rotation = Random.rotationUniform;
        }
	}
}
