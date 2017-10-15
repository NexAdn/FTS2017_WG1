using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishFire : MonoBehaviour {

    public float Timer = 3f;
    public GameObject FireMain;
    public GameObject CodePlane;

	// Use this for initialization
	void Start () {
        CodePlane.SetActive(false);
    }

    // Update is called once per frame
    /*void Update () {
		
	}*/



    public void OnTriggerStay (Collider coll)
    {
        /*foreach (GameObject o in coll.gameObject.GetComponents<GameObject>())
        {
            if (coll.gameObject == o)
            {
                Timer -= Time.deltaTime;
            }
            if (Timer <= 0)
            {
                o.GetComponent<ParticleSystem>().Stop();
                o.GetComponentsInChildren<ParticleSystem>()[0].Stop();
            }
        }*/
        if (coll.gameObject == FireMain)
        {
            Debug.Log(Timer.ToString());
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                foreach (ParticleSystem s in coll.gameObject.GetComponentsInChildren<ParticleSystem>())
                {
                    s.Stop();
                }
                foreach (AudioSource s in coll.GetComponentsInChildren<AudioSource>())
                {
                    s.Stop();
                }
                CodePlane.SetActive(true);
            }
        }
    }
}
