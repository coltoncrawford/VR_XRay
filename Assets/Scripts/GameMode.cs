using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour {

    public Transform swordSpawner;

    private Health health;

	// Use this for initialization
	void Start () {
        SpawnObjects[] obs = FindObjectsOfType<SpawnObjects>();
        int randomIndex = Random.Range(0, obs.Length);
        Transform sword = Instantiate(swordSpawner);
        sword.SetParent(obs[randomIndex].transform, false);
        health = obs[randomIndex].transform.parent.GetComponentInChildren<Health>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
