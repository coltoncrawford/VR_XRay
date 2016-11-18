using UnityEngine;
using System.Collections;

public class GunStuff : MonoBehaviour {

    public SteamVR_Controller.DeviceRelation controller;

    public GameObject bullet;

    public Transform forward;

    private float bulletTimer = 0;

    public int ammo;

    private int index = -1;

	// Use this for initialization
	void OnEnable () {
        index = -1;

    }
	
    void FireBullet() {
        
        if(bulletTimer >= 0.1f)
        {
            Rigidbody rb = ((GameObject)Instantiate(bullet, forward.position + (forward.forward), Quaternion.identity)).GetComponent<Rigidbody>();
            rb.AddForce((forward.forward + Random.insideUnitSphere * 0.01f).normalized * 10000);
            Destroy(rb.gameObject, 10.0f);

            bulletTimer = 0;
            ammo--;
        }
    }

	// Update is called once per frame
	void Update () {
        if(index == -1)
        {
            index = SteamVR_Controller.GetDeviceIndex(controller);
            return;
        }
        bulletTimer += Time.deltaTime;

        if (SteamVR_Controller.Input(index).GetHairTrigger()) {
            if(ammo > 0) { FireBullet(); }
        }
	}

    public bool IsEmpty
    {
        get { return ammo <= 0; }
    }
}
