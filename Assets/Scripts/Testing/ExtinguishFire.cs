using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishFire : MonoBehaviour {

    public int Timer = 1000;
    public GameObject fire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	/*void Update () {
		
	}*/

    public void OnTriggerEnter (Collider coll)
    {
        Debug.Log("trigger");
    }

    public void OnParticleCollision (GameObject other)
    {
        Debug.Log("collision");
        if (other == fire)
        {
            Debug.Log(Timer);
            if (--Timer == 0)
            {
                fire.SetActive(false);
            }
        }
    }
}
