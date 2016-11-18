using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour {

    [System.Serializable]
    public struct StateText
    {
        public string text;
        public Color color;
    }

    public Transform swordSpawner;
    public Text stateText;

    [Header("Display")]
    public StateText winText;
    public StateText lostText;

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
        if(!hasEnded)
        {
            if (gun.IsEmpty || health.IsDead)
            {
                hasEnded = true;
                StartCoroutine(CheckForEnd());
            }
        }

	}

    IEnumerator CheckForEnd()
    {
        yield return new WaitForSeconds(0.3f);

        bool win = health.IsDead;
        if(win)
        {
            stateText.text = winText.text;
            stateText.color = winText.color;
        } else
        {
            stateText.text = lostText.text;
            stateText.color = lostText.color;
        }
        StartCoroutine(ReloadLevel());
    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene(0);
    }
}
