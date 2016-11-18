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
    public Slider slider;
    public float timeToWin = 60;

    [Header("Display")]
    public StateText winText;
    public StateText lostText;

    public GunStuff gun;
    private Health health;
    private float currentTime;

    private bool hasEnded = false;

	// Use this for initialization
	void Start () {
        currentTime = timeToWin;
        //gun = FindObjectOfType<GunStuff>();

        Health[] healths = FindObjectsOfType<Health>();
        int randomIndex = Random.Range(0, healths.Length);
        Transform sword = Instantiate(swordSpawner);
        sword.SetParent(healths[randomIndex].obs.objects.transform, false);
        health = healths[randomIndex];
        Debug.Log(health == null);
        Debug.Log(gun == null);
    }
	
	// Update is called once per frame
	void Update () {
        if(!hasEnded)
        {
            //if (gun == null || health == null) return;
            currentTime -= Time.deltaTime;
            //if(slider != null)
            {
                slider.value = currentTime / timeToWin;
            }

            if (gun.IsEmpty || health.IsDead || currentTime <= 0.3f)
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
