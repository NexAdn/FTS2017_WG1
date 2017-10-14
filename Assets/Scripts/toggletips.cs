using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggletips : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ToggleTooltip (GameObject GO)
    {
        GO.SetActive(!GO.activeSelf);
    }
}
