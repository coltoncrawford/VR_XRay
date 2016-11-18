using UnityEngine;
using System.Collections;

public class GunStuff : MonoBehaviour {

    public SteamVR_Controller.DeviceRelation controller;

    public GameObject bullet;

    private float bulletTimer = 0;

    public int ammo;

	// Use this for initialization
	void Start () {
	}
	
    void FireBullet() {
        
        if(bulletTimer >= 0.1f)
        {
            Rigidbody rb = ((GameObject)Instantiate(bullet, transform.position + (transform.forward), Quaternion.identity)).GetComponent<Rigidbody>();
            rb.AddForce((transform.forward + Random.insideUnitSphere * 0.01f).normalized * 10000);
            Destroy(rb.gameObject, 10.0f);

            bulletTimer = 0;
            ammo--;
        }
    }

	// Update is called once per frame
	void Update () {
        bulletTimer += Time.deltaTime;

        if (SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(controller)).GetHairTrigger()) {
            if(ammo > 0) { FireBullet(); }
        }
	}
}
