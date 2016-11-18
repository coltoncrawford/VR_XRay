using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMode : MonoBehaviour {

    public Transform swordSpawner;
    public Text stateText;

    private GunStuff gun;
    private Health health;


    private bool hasEnded = false;
	// Use this for initialization
	void Start () {
        gun = FindObjectOfType<GunStuff>();

        SpawnObjects[] obs = FindObjectsOfType<SpawnObjects>();
        int randomIndex = Random.Range(0, obs.Length);
        Transform sword = Instantiate(swordSpawner);
        sword.SetParent(obs[randomIndex].transform, false);
        health = obs[randomIndex].transform.parent.GetComponentInChildren<Health>();
    }
	
	// Update is called once per frame
	void Update () {
	    if()
	}

    IEnumerator CheckForEnd()
    {
        yield return new WaitForSeconds(0.2f);

    }
}
