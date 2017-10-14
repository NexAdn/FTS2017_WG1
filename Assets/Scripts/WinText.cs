using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour {
    public Bomb bomb;

    private Text MyText;

	// Use this for initialization
	void Start () {
        MyText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        MyText.text = "Glückwunsch\n Du hattest noch " + bomb.TimerLabel.text + "\n Du hast die Bombe entschärft \n und bist vor deinem Entührer geflohen!";
    }
}
