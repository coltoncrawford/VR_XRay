using UnityEngine;
using System.Collections;

public class HiddenObjects : MonoBehaviour {

    public GameObject objects;

	// Use this for initialization
	void Start () {
        HideHiddenObjects();
    }
	

    public void ShowHiddenObjects()
    {
        objects.SetActive(true);
    }

    public void HideHiddenObjects()
    {
        objects.SetActive(false);
    }
}
