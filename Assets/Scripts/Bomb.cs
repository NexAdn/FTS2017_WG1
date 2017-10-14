using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour {

    public float TimeTilExplosion;
    public Text label;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        TimeTilExplosion -= Time.deltaTime;
        label.text = Mathf.Floor(TimeTilExplosion).ToString();
        if (TimeTilExplosion <= 0)
        {

        }
	}
}
