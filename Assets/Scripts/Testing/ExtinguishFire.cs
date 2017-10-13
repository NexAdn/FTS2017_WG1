using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishFire : MonoBehaviour {

    public float Timer = 3f;
    public GameObject flame;
    public GameObject fireMain;

	// Use this for initialization
	void Start () {
        Debug.Log("init");
	}

    // Update is called once per frame
    /*void Update () {
		
	}*/



    public void OnTriggerStay (Collider coll)
    {
        if (coll.gameObject == flame)
        {
            Timer -= Time.deltaTime;
            Debug.Log(Timer);
        }

        if (Timer <= 0)
        {
            flame.GetComponent<ParticleSystem>().Stop();
            fireMain.GetComponent<ParticleSystem>().Stop();
        }
    }
}
